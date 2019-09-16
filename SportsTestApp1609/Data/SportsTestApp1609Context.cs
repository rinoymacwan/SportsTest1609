using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsTestApp1609.Models;

namespace SportsTestApp1609.Models
{
    public class SportsTestApp1609Context : DbContext
    {
        public SportsTestApp1609Context (DbContextOptions<SportsTestApp1609Context> options)
            : base(options)
        {
        }

        public DbSet<SportsTestApp1609.Models.Test> Test { get; set; }

        public DbSet<SportsTestApp1609.Models.User> User { get; set; }

        public DbSet<SportsTestApp1609.Models.UserTestMapping> UserTestMapping { get; set; }
    }
}
