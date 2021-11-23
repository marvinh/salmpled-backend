using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
namespace Salmpled.Models
{
    public class SamplePlaylist : TimestampBaseEntity
    {
        public Guid Id { get; set; }
        [MaxLength(128)]
        public string SamplePlaylistName { get; set; }
        public string UserId {get; set;}
        public virtual User User {get; set;}
        public virtual List<SampleSamplePlaylist> SampleSamplePlaylists { get; set; }
        public virtual List<SamplePlaylistSamplePlaylistGenre> SamplePlaylistSamplePlaylistGenres { get; set; }
        public string SamplePlaylistImageRegion { get; set; }
        public string SamplePlaylistImageBucket { get; set; }
        public string SamplePlaylistImageKey { get; set; }

        [DefaultValue(false)]
        public bool Published {get; set;}

    }
}