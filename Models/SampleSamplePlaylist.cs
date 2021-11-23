using System;
namespace Salmpled.Models
{
    public class SampleSamplePlaylist {
    public Guid SampleId { get; set; }
    public virtual Sample Sample { get; set; }
    public Guid SamplePlaylistId { get; set; }
    public virtual SamplePlaylist SamplePlaylist { get; set; }

    }
    
}