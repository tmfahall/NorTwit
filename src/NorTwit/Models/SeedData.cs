using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace NorTwit.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.Tweet.Any())
            {
                return;
            }

            context.Tweet.AddRange(
                new Tweet
                {
                    Message = "Test1",
                    TimeStamp = DateTime.Parse("January 1, 2000 10:00 AM")
                },
                new Tweet
                {
                    Message = "Test2",
                    TimeStamp = DateTime.Parse("January 2, 2000 10:00 PM")
                });

            context.SaveChanges();
        }
    }
}
