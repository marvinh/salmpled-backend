using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Salmpled.Models
{
   public class Follow : TimestampBaseEntity
{
    public string FollowerId { get; set; }
    public string FolloweeId { get; set; }
    public virtual User Follower { get; set; }
    public virtual User Followee { get; set; }
}
}