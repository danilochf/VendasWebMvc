using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using VendasWebMvc.Servicos;
using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Servicos.Exceptions;
using System.Diagnostics;

namespace VendasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresServicos _vendedoresServicos;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController(VendedoresServicos vendedoresServicos, ServicoDepartamento servicoDepartamento)
        {
            _vendedoresServicos = vendedoresServicos;
            _servicoDepartamento = servicoDepartamento;
        }
        public IActionResult Index()
        {
            var list = _vendedoresServicos.FindAll();
                        
            return View(list);
        }

        public IActionResult Criar()
        {
            var departamentos = _servicoDepartamento.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Vendedor vendedor)
        {
            _vendedoresServicos.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _vendedoresServicos.FindById(id.Value);            

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Exite" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedoresServicos.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _vendedoresServicos.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Exite" });
            }

            return View(obj);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _vendedoresServicos.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Exite" });
            }

            List<Department> departamentos = _servicoDepartamento.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids não correspondem" });
            }

            try
            {
                _vendedoresServicos.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
        
    }
}
