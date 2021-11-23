using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Salmpled.Models
{
    public class SampleDTO
    {
        public Guid Id { get; set; }
        public string OrginalFileName { get; set; }
        public string RenamedFileName { get; set; }
        public string UserId { get; set; }
        //public User User { get; set; }
        public string SignedMP3URL {get; set;}
        public string Description {get; set;}
        //public List<SampleSamplePlaylist> SampleSamplePlaylists { get; set; }
        public List<SampleSampleTag> SampleSampleTags { get; set; }
        public Guid SamplePackId {get; set;}
        //public SamplePackDTO SamplePackDTO {get; set;}

    }
}