using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCofee.Web.ViewModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsArchived { get; set; }
    }
}
