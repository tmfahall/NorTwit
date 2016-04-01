using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorTwit.Models
{
    public interface ITweetRepository
    {
        void Add(Tweet tweet);
        IEnumerable<Tweet> GetAll();
        Tweet Find(int Id);
    }
}
