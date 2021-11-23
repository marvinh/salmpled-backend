using System;
namespace Salmpled.Models
{
    public class SampleSampleTag {
    public Guid SampleId { get; set; }
    public virtual Sample Sample { get; set; }
    public Guid SampleTagId { get; set; }
    public virtual SampleTag SampleTag { get; set; }

    }
    
}