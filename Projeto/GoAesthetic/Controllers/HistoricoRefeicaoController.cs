using GoAesthetic.Controllers.ControllersBase;
using GoAesthetic.Models;
using GoAestheticEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GoAesthetic.Controllers
{
    public class HistoricoRefeicaoController : BaseController
    {
        public HistoricoRefeicaoController(GoAestheticDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();

        }
    }
}