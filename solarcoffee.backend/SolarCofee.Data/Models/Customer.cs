using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCofee.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerAddresse PrimaryAddress { get; set; }
    }
}
