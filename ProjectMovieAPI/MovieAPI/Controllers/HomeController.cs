using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
            TempData["savedQuery"] = query;
            List<Result> moviesResults = movieDAL.SearchMoviesString(query); // SearchMoviesString is WIP
            return View(moviesResults);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Favorites()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var favorites = _movieContext.Favorites.Where(x => x.UserId == userId).ToList();

            List<Movie> UserFavorites = new List<Movie>();

            foreach (var fav in favorites)
            {
                Movie favorite = new Movie();
                favorite = movieDAL.SearchMoviesId((int)fav.MovieId);

                UserFavorites.Add(favorite);
            }

            return View(UserFavorites);
        }

        [HttpPost]
        public IActionResult AddToFavorites(int id, string routedQuery)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var favorites = _movieContext.Favorites.Where(x => x.UserId == userId).ToList();

            Favorites favorite = new Favorites()
            {
                UserId = userId,
                MovieId = id               
            };

            if (ModelState.IsValid)
            {
                _movieContext.Favorites.Add(favorite);
                _movieContext.SaveChanges();

                return RedirectToAction("Result", new { query = routedQuery });
            }
            else
            {
                TempData["Error"] = "Could not add to favorites list.";
                return RedirectToAction("Result");
            }

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
