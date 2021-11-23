using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Salmpled.Models
{
    public class SampleTag : TimestampBaseEntity
    {
        public Guid Id { get; set; }

        [MaxLength(64)]
        public string SampleTagName { get; set; }

        public virtual List<SampleSampleTag> SampleSampleTags { get; set; }

    }
}