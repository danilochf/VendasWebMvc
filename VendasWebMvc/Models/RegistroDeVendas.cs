using System;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public StatusDeVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroDeVendas()
        {
        }

        public RegistroDeVendas(int id, DateTime data, double total, StatusDeVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Total = total;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
