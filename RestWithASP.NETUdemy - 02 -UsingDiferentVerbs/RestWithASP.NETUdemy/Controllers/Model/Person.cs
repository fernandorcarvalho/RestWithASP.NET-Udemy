using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.NETUdemy.Controllers.Model
{
    public class Person
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
