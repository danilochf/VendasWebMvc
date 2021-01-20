using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        private readonly VendasWebMvcContext _context;
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }
        public Department Departamento { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();

        public Vendedor()
        {            

        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Department departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionaVenda(RegistroDeVendas rv)
        {
            Vendas.Add(rv);
        }

        public void RemoverVenda(RegistroDeVendas rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas(DateTime dtInicial, DateTime dtFinal)
        {            
            return Vendas.Where(rv => rv.Data >= dtInicial && rv.Data <= dtFinal).Sum(rv => rv.Total);
        }
    }
}
