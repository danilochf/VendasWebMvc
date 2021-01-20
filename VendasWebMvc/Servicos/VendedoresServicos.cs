using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Servicos.Exceptions;

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
            return _context.Vendedor.Include(obj => obj.Departamento).ToList();
        }        

        public void Inserir(Vendedor obj)
        {           
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor obj)
        {
            if (!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não existe");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }
}
