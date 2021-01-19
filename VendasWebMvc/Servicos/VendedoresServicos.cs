using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;

namespace VendasWebMvc.Servicos
{
    public class VendedoresServicos
    {
        private readonly VendasWebMvcContext _context;

        public VendedoresServicos(VendasWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
    }
}
