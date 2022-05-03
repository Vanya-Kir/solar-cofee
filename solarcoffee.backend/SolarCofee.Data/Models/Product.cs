 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SolarCofee.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }

        public decimal Price { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsArchived { get; set; }
    }
}
