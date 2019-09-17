using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTestApp1609.Models
{
    public class UserTestMapping
    {
        public int Id { get; set; }
        public int? Distance { get; set; }
        public int? Time { get; set; }
        public string FitnessRating { get; set; }

        public int TId { get; set; }
        [ForeignKey("TId")]
        public Test Test { get; set; }

        public int UId { get; set; }
        [ForeignKey("UId")]
        public User User { get; set; }
    }
}
