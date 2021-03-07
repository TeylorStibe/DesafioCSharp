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

        public IActionResult Creation(string name, DateTime birthdate, string cpf, string address, string city, string reg)
        {
            if (reg == "Cadastrar")
            {
                if (name == null || birthdate == null || cpf == null || address == null || city == null)
                {
                    ViewData["result"] = "Algum dado não foi preenchido.";
                    return View();
                }

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

            return View();
        }

        public IActionResult Edition(string name, DateTime birthdate,string cpf, string address, string city)
        {
            if (name == null || birthdate == null || cpf == null  address== null || city == null)
                {
                ViewData["result"] = "Algum dado de Endereco não foi preenchido.";
                return View();
            }
            UserDAL userdal = new UserDAL();
            User user = new User();

            var listagem = userdal.GetAll();

            ViewData["result"] = userdal.Edit(user);

            return View();
        }

        public IActionResult Show(string delete, int id)
        {

            UserDAL userdal = new UserDAL();
            User user = new User();

            if (delete == "Deletar")
            {
                user.id = id;
                ViewData["result"] = userdal.Delete(user);
                return View();
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
