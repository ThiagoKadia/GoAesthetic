using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Models;
using GoAestheticEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GoAesthetic.Controllers
{
    public class HomeController : BaseController
    {      
        public HomeController(GoAestheticDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            return View();

        }
    }
}