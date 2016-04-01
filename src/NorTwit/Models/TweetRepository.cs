using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorTwit.Models
{
    public class TweetRepository : ITweetRepository
    {
        static ConcurrentDictionary<int, Tweet> _tweets = new ConcurrentDictionary<int, Tweet>();

        public void Add(Tweet tweet)
        {
            tweet.ID = Guid.NewGuid().GetHashCode();
            _tweets[tweet.ID] = tweet;
        }

        public Tweet Find(int Id)
        {
            Tweet tweet;
            _tweets.TryGetValue(Id, out tweet);
            return tweet;
        }

        public IEnumerable<Tweet> GetAll()
        {
            return _tweets.Values;
        }
    }
}
