using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTestApp1609.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
