using DapperCV.Business.Interfaces;
using DapperCV.Entities.Concrete;
using DapperCV.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DapperCV.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericService<Skill> _skillService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public HomeController(ILogger<HomeController> logger, IGenericService<Skill> skillService) : this(logger)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            return View(_skillService.GetAllService());
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
