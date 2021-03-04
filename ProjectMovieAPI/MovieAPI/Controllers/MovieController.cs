using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDBContext _movieContext;
        public MovieController(MovieDBContext context)
        {
            _movieContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
