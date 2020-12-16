using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> lista = new List<Department>();
            lista.Add(new Department { Id = 1, Nome = "Eletrônicos" });
            lista.Add(new Department { Id = 2, Nome = "Móveis e Decoração" });

            return View(lista);
        }
    }
}
