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
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using Newtonsoft.Json.Serialization;
namespace Salmpled.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SalmpledContext _context;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private static IAmazonS3 _s3Client;
        private static readonly string bucketName = "sampled-demo"; 
        public UsersController(SalmpledContext context, IAmazonS3 s3Client)
        {
            _context = context;
            _s3Client = s3Client;
        }

        [HttpGet("usernameAvailable")]
        [Authorize]
        public async Task<ActionResult<Boolean>> usernameAvailable([FromQuery]string username = "")
        {   
            
            try
            {
                String header = this.HttpContext.Request.Headers["Authorization"];
                var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;
                var decoded = await auth.VerifyIdTokenAsync(header.Split(" ")[1]);
                var uid = decoded.Uid;
                var checkUsername = username;
                if(checkUsername == "") {
                    return false;
                }
                var user = await _context.User.FindAsync(uid);
                if (user != null)
                {
                    var exists = await _context.User.Where<User>(user => user.Username == checkUsername).FirstOrDefaultAsync<User>();
                    return exists == null;
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (FirebaseException ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }

        }

        [HttpPut("setUsername")]
        [Authorize]
        public async Task<ActionResult<User>> setUsername(User updatedUser)
        {
            String header = this.HttpContext.Request.Headers["Authorization"];
            var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;
            try
            {
                var decoded = await auth.VerifyIdTokenAsync(header.Split(" ")[1]);
                var uid = decoded.Uid;
                var user = await _context.User.FindAsync(uid);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    user.Username = updatedUser.Username;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException) when (!_context.User.Any(u => u.Id == uid))
                    {
                        return NotFound();
                    }
                }
            }
            catch (FirebaseException ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }

            return NoContent();

        }

        [HttpPost("existsOrCreate")]
        [Authorize]
        public async Task<ActionResult<User>> existsOrCreate()
        {
            try
            {
            String header = this.HttpContext.Request.Headers["Authorization"];
            var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;

                var decoded = await auth.VerifyIdTokenAsync(header.Split(" ")[1]);
                var uid = decoded.Uid;
                var user = await _context.User.FindAsync(uid);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    var fuser = await auth.GetUserAsync(uid);
                    var newuser = new User
                    {
                        Id = uid,
                        AuthProvider = fuser.ProviderId,
                        Email = fuser.Email,
                    };
                    _context.User.Add(newuser);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("ExistsOrCreate", newuser);
                }
            }
            catch (FirebaseException ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
        // [HttpPost("UserImage")]
        // [Authorize]
        // public async Task<ActionResult<User>> UserImage([FromForm]IFormFile UserImageFile)
        // {
        //     Console.WriteLine("object1"+JsonConvert.SerializeObject(UserImageFile));
        //     try{
        //         Console.WriteLine("object2"+JsonConvert.SerializeObject(UserImageFile));
        //     String header = this.HttpContext.Request.Headers["Authorization"];
        //     var auth = FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance;

        //         var decoded = await auth.VerifyIdTokenAsync(header.Split(" ")[1]);
        //         var uid = decoded.Uid;
        //         var user = await _context.User.FindAsync(uid);
        //         if(user != null){
        //             var filePath = Path.GetTempFileName();
                    
        //             using (var stream = System.IO.File.Create(filePath))
        //             {
        //                 await UserImageFile.CopyToAsync(stream);
        //             }
        //             var extension = Path.GetExtension(UserImageFile.FileName);
        //             var fileTransferUtility = new TransferUtility(_s3Client);
        //             if(user.UserImage != null) {
                        
        //                 var fileId = Guid.NewGuid();
        //                 var key = $"UserImages/{user.Id}/{fileId}{extension}";
        //                 var UserImage = new UserImage {
        //                     UserId = user.Id,
        //                     User = user,
        //                     Id = fileId,
        //                     UserImageRegion = bucketRegion.ToString(),
        //                     UserImageBucket = bucketName,
        //                     UserImageKey = $"UserImages/{fileId}{extension}"
        //                 };
        //                 _context.UserImage.Add(UserImage);
        //                 await _context.SaveChangesAsync();
        //                 return CreatedAtAction("UserImage", user);
        //             }else{
        //                 var fileId = user.UserImage.Id;
        //                 var key = $"UserImages/{user.Id}/{user.UserImage.Id}{extension}";
        //                 await _s3Client.DeleteObjectAsync(bucketName,user.UserImage.UserImageKey);
        //                 await fileTransferUtility.UploadAsync(filePath, bucketName, key);
        //                 user.UserImage.UserImageKey =  $"UserImages/{fileId}{extension}";
        //                 await _context.SaveChangesAsync();
        //                 return user;
        //             }
        //         }else{
        //             return BadRequest();
        //         }

        //     }catch (FirebaseException ex){
        //          Console.WriteLine(ex);
        //         return BadRequest();
        //     }
             
        // }
    }
}
