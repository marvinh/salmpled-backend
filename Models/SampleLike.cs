using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Salmpled.Models
{
    public class SampleLike : TimestampBaseEntity
    {
        public Guid Id { get; set; }

        public Guid SampleId {get; set;}
        public virtual Sample Sample { get; set; }

        public string UserId {get; set;}
        public virtual User User {get; set;}

    }
}