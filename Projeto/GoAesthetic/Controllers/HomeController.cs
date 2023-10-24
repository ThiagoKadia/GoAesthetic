using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Models;
using GoAestheticEntidades;
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

        public async Task<IActionResult> Index()
        {
            if (!VerificaUsuarioLogado())
                return RedirectToAction("Index", "Login");


            return View();

        }
    }
}