using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorTwit.Models
{
    public class UserTweet
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public int TweetId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Tweet Tweet { get; set; }
    }
}
