using System.Collections.Generic;
using System;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Department()
        { 
        }

        public Department(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionaVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendas(DateTime Inicial, DateTime Final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(Inicial, Final));
        }
    }
}
