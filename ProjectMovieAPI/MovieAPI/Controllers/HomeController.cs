using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MovieDBContext _movieContext;
        public HomeController(MovieDBContext context)
        {
            _movieContext = context;
        }

        private MovieDAL movieDAL = new MovieDAL(); 
        public IActionResult Result(string query)
        {
            
            List<Result> moviesResults = movieDAL.SearchMoviesString(query); // SearchMoviesString is WIP
            return View(moviesResults);
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
