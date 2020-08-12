using RestWithASP.NETUdemy.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.NETUdemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);

        Book FindById(long Id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long Id);
    }
}
