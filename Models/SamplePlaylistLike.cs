using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Salmpled.Models
{
    public class SamplePlaylistLike : TimestampBaseEntity
    {
        public Guid Id { get; set; }
        public Guid SamplePackId {get; set;}
        public virtual SamplePack SamplePack { get; set; }
        public virtual User User {get; set;}
        public string UserId {get; set;}

    }
}