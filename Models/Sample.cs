using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Salmpled.Models
{
    public class Sample : TimestampBaseEntity
    {
        public Guid Id { get; set; }
        public string OrginalFileName { get; set; }
        public string RenamedFileName { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string Region { get; set; }
        public string Bucket { get; set; }
        public string UncompressedSampleKey { get; set; }
        public string CompressedSampleKey {get; set;}
        public string Description {get; set;}
        public virtual List<SampleSamplePlaylist> SampleSamplePlaylists { get; set; }
        public virtual List<SampleSampleTag> SampleSampleTags { get; set; }
        public Guid SamplePackId {get; set;}
        public virtual SamplePack SamplePack {get; set;}

    }
}