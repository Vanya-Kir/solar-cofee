using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SolarCofee.Data.Models
{
    public class CustomerAddresse
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        [MaxLength(100)]
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(30)]
        public string Country { get; set; }

    }
}
