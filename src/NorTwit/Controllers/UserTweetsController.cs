using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using NorTwit.Models;

namespace NorTwit.Controllers
{
    [Produces("application/json")]
    [Route("api/UserTweets")]
    public class UserTweetsController : Controller
    {
        private ApplicationDbContext _context;

        public UserTweetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserTweets
        [HttpGet]
        public IEnumerable<UserTweet> GetUserTweet()
        {
            return _context.UserTweet;
        }

        // GET: api/UserTweets/5
        [HttpGet("{id}", Name = "GetUserTweet")]
        public IActionResult GetUserTweet([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            UserTweet userTweet = _context.UserTweet.Single(m => m.Id == id);

            if (userTweet == null)
            {
                return HttpNotFound();
            }

            return Ok(userTweet);
        }

        // PUT: api/UserTweets/5
        [HttpPut("{id}")]
        public IActionResult PutUserTweet(string id, [FromBody] UserTweet userTweet)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != userTweet.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(userTweet).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTweetExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/UserTweets
        [HttpPost]
        public IActionResult PostUserTweet([FromBody] UserTweet userTweet)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.UserTweet.Add(userTweet);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserTweetExists(userTweet.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetUserTweet", new { id = userTweet.Id }, userTweet);
        }

        // DELETE: api/UserTweets/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUserTweet(string id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            UserTweet userTweet = _context.UserTweet.Single(m => m.Id == id);
            if (userTweet == null)
            {
                return HttpNotFound();
            }

            _context.UserTweet.Remove(userTweet);
            _context.SaveChanges();

            return Ok(userTweet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTweetExists(string id)
        {
            return _context.UserTweet.Count(e => e.Id == id) > 0;
        }
    }
}