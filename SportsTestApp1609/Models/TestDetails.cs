using SportsTestApp1609.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTestApp1609.Models
{
    public class TestDetails
    {
        public Test CurrentTest { get; set; }
        public List<UserTestMapping> CurrentUserTestMapping { get; set; }

        public TestDetails(Test test, List<UserTestMapping> details)
        {
            this.CurrentTest = test;
            this.CurrentUserTestMapping = details;
        }
    }
}
