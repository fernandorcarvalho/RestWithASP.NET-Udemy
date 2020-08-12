using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASP.NETUdemy.Model.Base;

namespace RestWithASP.NETUdemy.Controllers.Model
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate{ get; set; }
    }
}
