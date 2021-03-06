using DesafioCSharp_Teylor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Creation(string name, DateTime birthdate, string cpf, string address, string city)
        {
            ViewBag.name= "";
            ViewBag.birthdate= "";
            ViewBag.cpf= "";
            ViewBag.address= "";
            ViewBag.city= "";
            User user = new User();
            UserDAL userdal = new UserDAL();
            
            user.Name = name;
            user.Birthdate = birthdate;
            user.CPF = cpf;
            user.Address = address;
            user.City = city;

            ViewData["result"] = userdal.Insert(user);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
