using RestWithASP.NETUdemy.Controllers.Model;
using RestWithASP.NETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP.NETUdemy.Business.Implementation
{
    public class BookBusinessImpl : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        public BookBusinessImpl (IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long Id)
        {
            return _repository.FindById(Id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
