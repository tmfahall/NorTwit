using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorTwit.Models
{
    public class Tweet
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
