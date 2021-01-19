using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Servicos;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresServicos _vendedoresServicos;

        public VendedoresController(VendedoresServicos vendedoresServicos)
        {
            _vendedoresServicos = vendedoresServicos;
        }
        public IActionResult Index()
        {
            var list = _vendedoresServicos.FindAll();
            return View(list);
        }
    }
}
