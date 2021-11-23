using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Salmpled.Models;
using FirebaseAdmin;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;
namespace Salmpled.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class SamplePackController : ControllerBase
    {
        private readonly SalmpledContext _context;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 _s3Client;
        private static readonly string bucketName = "salmpled-demo";

        private static readonly double duration = 12;

        public SamplePackController(SalmpledContext context, IAmazonS3 s3Client)
        {
            _context = context;
            _s3Client = s3Client;
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

        [HttpGet("view-edit/{id}")]
        [Authorize]
        public async Task<ActionResult<SamplePackDTO>> GetSamplePack(Guid id)
        {

            try
            {
                String header = this.HttpContext.Request.Headers["Authorization"];
                var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;
                var decoded = await auth.VerifyIdTokenAsync(header.Split(" ")[1]);
                var uid = decoded.Uid;
                User user = await _context.User.FindAsync(uid);
                if (user != null)
                {
                    var samplePack = await _context.SamplePack
                    .Where(s => s.Id == id && s.UserId == user.Id)
                    .FirstOrDefaultAsync<SamplePack>();
                    if (samplePack != null)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(samplePack.Samples, Formatting.Indented,
new JsonSerializerSettings()
{
    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
}));
                        SamplePackDTO dto = new SamplePackDTO
                        {
                            Id = samplePack.Id,
                            UserId = samplePack.UserId,
                            Samples = samplePack.Samples?.Select(s => SampleToDTO(s)).ToList(),
                            SignedImageURL = samplePack.SamplePackImageKey != null ? GeneratePreSignedURL(samplePack.SamplePackImageKey) : "",
                            SamplePackSamplePackGenres = samplePack.SamplePackSamplePackGenres,
                            SamplePackName = samplePack.SamplePackName,
                            Description = samplePack.Description,
                            Published = samplePack.Published,
                            PublishedDate = samplePack.PublishedDate,
                        };
                        return Ok(dto);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (FirebaseException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }

        }

        // private static IEnumerable<SampleDTO> SamplesToDTO(List<Sample> Samples, User user)
        // {

        //     var samples = Samples?.Select(s => new SampleDTO
        //     {
        //         Id = s.Id,
        //         OrginalFileName = s.OrginalFileName,
        //         RenamedFileName = s.RenamedFileName,
        //         SamplePackId = s.SamplePackId,
        //         User = user,
        //         UserId = user.Id,
        //         //SamplePackDTO = SamplePackToDTO(s.SamplePack),
        //         SampleSamplePlaylists = s.SampleSamplePlaylists,
        //         SampleSampleTags = s.SampleSampleTags,
        //         SignedMP3URL = s.CompressedSampleKey != "" ? GeneratePreSignedURL(s.CompressedSampleKey) : null,
        //     });
        //     return samples;
        // }
        // private static SamplePackDTO SamplePackToDTO(SamplePack item) =>
        // new SamplePackDTO
        // {
        //     Id = item.Id,
        //     SamplePackName = item.SamplePackName,
        //     SignedImageURL = item.SamplePackImageKey != "" ? GeneratePreSignedURL(item.SamplePackImageKey) : null,
        //     Samples = SamplesToDTO(item.Samples,item.User)?.ToList<SampleDTO>(),
        // };

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

        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult<SamplePackDTO>> CreateSamplePack()
        {

            try
            {
                String header = this.HttpContext.Request.Headers["Authorization"];
                var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;
                var decoded = await auth.VerifyIdTokenAsync(header.Split(" ")[1]);
                var uid = decoded.Uid;
                User user = await _context.User.FindAsync(uid);
                if (user != null)
                {
                    var newSamplePack = new SamplePack
                    {
                        UserId = user.Id,
                    };
                    _context.SamplePack.Add(newSamplePack);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("CreateSamplePack", newSamplePack);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (FirebaseException e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }

        }

    }
}