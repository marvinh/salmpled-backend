using System;
namespace Salmpled.Models
{
    public class SamplePackSamplePackGenre {
    public Guid SamplePackId { get; set; }
    public virtual SamplePack SamplePack { get; set; }
    public Guid SamplePackGenreId { get; set; }
    public virtual SamplePackGenre SamplePackGenre { get; set; }
    }
    
}