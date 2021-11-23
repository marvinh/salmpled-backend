
using System;

using System.Collections.Generic;
namespace Salmpled.Models
{
    public class SamplePackDTO
    {
        public Guid Id { get; set; }
        public string SamplePackName { get; set; }
        public List<SampleDTO> Samples { get; set; }
        public List<SamplePackSamplePackGenre> SamplePackSamplePackGenres { get; set; }
        public string SignedImageURL {get;set;}
        public string UserId {get; set;}
        //public User User {get; set;}
        public string Description {get; set;}
        public bool Published {get; set;} 
        public DateTime PublishedDate {get;set;}

    }
}