using System.Collections.Generic;

namespace VendasWebMvc.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor vendedor { get; set; }
        public ICollection<Department> Departamentos { get; set; }


    }
}
