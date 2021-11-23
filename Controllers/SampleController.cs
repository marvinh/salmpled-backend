using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Salmpled.Models;
using FirebaseAdmin;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Newtonsoft.Json.Serialization;
namespace Salmpled.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class SampleController : ControllerBase
    {

        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 _s3Client;
        private static readonly string bucketName = "salmpled-demo";

        private static readonly double duration = 12;

        private readonly SalmpledContext _context;

        static string GeneratePreSignedURL(string objectKey)
        {
            string urlString = "";
            try
            {
                GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    Expires = DateTime.UtcNow.AddHours(duration)
                };
                urlString = _s3Client.GetPreSignedURL(request1);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            return urlString;
        }

        static string ConvertToFLAC(string file, string convertedExtension)
        {
            string result = string.Empty;
            string input = string.Empty;
            string output = string.Empty;
            try
            {
                string ffmpegFilePath = "ffmpeg"; // path of ffmpeg.exe - please replace it for your options.
                FileInfo fi = new FileInfo(file);
                string filename = Path.GetFileNameWithoutExtension(fi.Name);
                string extension = Path.GetExtension(fi.Name);
                input = file;
                output = fi.DirectoryName + filename + convertedExtension;

                var processInfo = new ProcessStartInfo(ffmpegFilePath)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                processInfo.Arguments = $"-i {input} -c:a flac {output}";
                try
                {
                    Process process = System.Diagnostics.Process.Start(processInfo);
                    result = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    process.Close();
                }
                catch (Exception)
                {
                    result = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                string error = ex.Message;
            }
            Console.WriteLine(result);
            return output;
        }

        public static string ConvertToMp3(string file, string convertedExtension)
        {
            string result = string.Empty;
            string input = string.Empty;
            string output = string.Empty;
            try
            {
                string ffmpegFilePath = "ffmpeg"; // path of ffmpeg.exe - please replace it for your options.
                FileInfo fi = new FileInfo(file);
                string filename = Path.GetFileNameWithoutExtension(fi.Name);
                string extension = Path.GetExtension(fi.Name);
                input = file;
                output = fi.DirectoryName + filename + convertedExtension;

                var processInfo = new ProcessStartInfo(ffmpegFilePath)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                processInfo.Arguments = $"-i {input} {output}";
                try
                {
                    Process process = System.Diagnostics.Process.Start(processInfo);
                    result = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    process.Close();
                }
                catch (Exception)
                {
                    result = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                string error = ex.Message;
            }

            Console.WriteLine(result);
            return output;
        }

        private static SampleDTO SampleToDTO(Sample sample)
        {

            var dto = new SampleDTO
            {
                Id = sample.Id,
                OrginalFileName = sample.OrginalFileName,
                RenamedFileName = sample.RenamedFileName,
                SamplePackId = sample.SamplePackId,
                UserId = sample.UserId,
                SampleSampleTags = sample.SampleSampleTags,
                SignedMP3URL = sample.CompressedSampleKey != "" ? GeneratePreSignedURL(sample.CompressedSampleKey) : null,
            };
            return dto;
        }


        public SampleController(SalmpledContext context, IAmazonS3 s3Client)
        {
            _context = context;
            _s3Client = s3Client;
        }

        public class UploadSamplesInputModel
        {
            public ICollection<IFormFile> SampleFiles { get; set; }
            public Guid SamplePackId { get; set; }
        }

        [HttpPost("uploadsamples")]
        [Authorize]
        public async Task<ActionResult<List<SampleDTO>>> UploadSample([FromForm] ICollection<IFormFile> SampleFiles, [FromForm] Guid SamplePackId)
        {

            Console.WriteLine(SamplePackId);
            try
            {
                Console.WriteLine(SamplePackId);
                String header = this.HttpContext.Request.Headers["Authorization"];
                var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;
                var decoded = await auth.VerifyIdTokenAsync(header.Split(" ")[1]);
                var uid = decoded.Uid;
                User user = await _context.User.FindAsync(uid);
                SamplePack samplePack = await _context.SamplePack.FindAsync(SamplePackId);
                List<Sample> samples = new List<Sample>();

                Console.WriteLine(JsonConvert.SerializeObject(samplePack.Samples, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }));

                if (samplePack == null || user == null)
                {
                    Console.WriteLine("empty user or sample pack");
                    Console.WriteLine(SamplePackId);
                    return NotFound();
                }

                foreach (var sampleFile in SampleFiles)
                {
                    //Console.WriteLine(JsonConvert.SerializeObject(SampleFile));
                    var filePath = Path.GetTempFileName();
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await sampleFile.CopyToAsync(stream);
                    }
                    var extension = Path.GetExtension(sampleFile.FileName);
                    var flac = ConvertToFLAC(filePath, ".flac");
                    var mp3 = ConvertToMp3(filePath, ".mp3");
                    var fileTransferUtility = new TransferUtility(_s3Client);
                    var flacKey = "audio/flac/" + Guid.NewGuid() + ".flac";
                    var mp3Key = "audio/mp3/" + Guid.NewGuid() + ".mp3";
                    await fileTransferUtility.UploadAsync(flac, bucketName, flacKey);
                    await fileTransferUtility.UploadAsync(flac, bucketName, mp3Key);
                    var mp3URL = GeneratePreSignedURL(mp3Key);
                    samples.Add(
                        new Sample
                        {
                            SamplePackId = samplePack.Id,
                            UserId = user.Id,
                            OrginalFileName = Path.GetFileNameWithoutExtension(sampleFile.FileName),
                            RenamedFileName = Path.GetFileNameWithoutExtension(sampleFile.FileName),
                            Region = bucketRegion.ToString(),
                            Bucket = bucketName,
                            CompressedSampleKey = mp3Key,
                            UncompressedSampleKey = flacKey,
                        }
                    );

                }
                
                await _context.Sample.AddRangeAsync(samples);
                await _context.SaveChangesAsync();
                var samplesDto = new List<SampleDTO>();
                foreach(var sample in samples) {
                    samplesDto.Add(SampleToDTO(sample));
                }
                return Ok(samplesDto);
                //var samplePack2 = await _context.SamplePack.FindAsync(SamplePackId); 

                // Console.WriteLine(JsonConvert.SerializeObject(samplePack.Samples, Formatting.Indented,
                // new JsonSerializerSettings()
                // {
                //     ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                // }));

                //var data = await _context.SamplePack.FindAsync(SamplePackId);
                //var response = _context.Sample.Where(s => s.SamplePackId == SamplePackId).Select(s => SampleToDTO(s)).ToList();
                //return Ok(response);

            }
            catch (FirebaseException e)
            {
                Console.WriteLine("Caught Here");
                Console.WriteLine(e);
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught Here");
                Console.WriteLine(e);
                return BadRequest();
            }

        }

    }
}