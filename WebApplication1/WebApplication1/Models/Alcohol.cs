using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Alcohol
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
    }
}
