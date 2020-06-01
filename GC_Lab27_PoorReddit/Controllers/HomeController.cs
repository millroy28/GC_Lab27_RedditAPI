using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GC_Lab27_PoorReddit.Models;

namespace GC_Lab27_PoorReddit.Controllers
{

    public class HomeController : Controller
    {
        private readonly RedditDAL RD = new RedditDAL();
                
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult DisplayPosts(string subreddit)
        {
            List<RedditPost> gp = RD.GetPost(subreddit);
            return View(gp);
        }

        public IActionResult SubredditSearch()
        {
            return View();
        }
        
    }
}
