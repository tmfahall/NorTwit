using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using NorTwit.Models;

namespace NorTwit.Controllers
{
    public class TweetsController : Controller
    {
        private ApplicationDbContext _context;

        public TweetsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Tweets
        public IActionResult Index()
        {
            return View(_context.Tweet.ToList());
        }

        // GET: Tweets/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tweet tweet = _context.Tweet.Single(m => m.ID == id);
            if (tweet == null)
            {
                return HttpNotFound();
            }

            return View(tweet);
        }

    }
}
