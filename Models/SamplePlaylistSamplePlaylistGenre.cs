using System;
namespace Salmpled.Models
{
    public class SamplePlaylistSamplePlaylistGenre {
    public Guid SamplePlaylistId { get; set; }
    public virtual SamplePlaylist SamplePlaylist { get; set; }
    public Guid SamplePlaylistGenreId { get; set; }
    public virtual SamplePlaylistGenre SamplePlaylistGenre { get; set; }
    }
    
}