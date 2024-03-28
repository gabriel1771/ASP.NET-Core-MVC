using LanchesMac2.Models;
using LanchesMac2.Repositories.Interfaces;
using LanchesMac2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LanchesMac2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ILanchesRepository _lancheRepository;

        public HomeController(ILanchesRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            
            return View(homeViewModel);
        }
        public IActionResult Demo()
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
