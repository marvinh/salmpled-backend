using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Salmpled.Models
{
    public class SamplePlaylistGenre : TimestampBaseEntity
    {
        public Guid Id { get; set; }

        [MaxLength(64)]
        public string GenreName { get; set; }
        public virtual List<SamplePlaylistSamplePlaylistGenre> SamplePlaylistSamplePlaylistGenres { get; set; }
    }
}