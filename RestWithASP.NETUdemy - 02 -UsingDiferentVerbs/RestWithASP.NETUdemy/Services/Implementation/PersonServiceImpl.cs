using RestWithASP.NETUdemy.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASP.NETUdemy.Services.Implementation
{
    public class PersonServiceImpl : IPersonService
    {
        private Model.Context.MySqlContext _context;

        public PersonServiceImpl(Model.Context.MySqlContext context)
        {
            _context = context;
        }

        // Contador responsável por gerar um fake ID já que não temos acesso ao Banco de Dados neste Mock 
        private volatile int count;

        // Método responsável por criar uma nova pessoa
        // Se tivéssemos um banco de dados esse seria o momento de persistir os dados
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return person;
        }

        // Método responsável por deletar o resgistro de uma pessoa a partir do ID
        public void Delete(long Id)
        {
        }
        
        // Método responsável por retornar todas as pessoas
        // nesta implemtnação os dados estão mockados
        public List<Person> FindAll()
        {
            //    List<Person> persons = new List<Person>();

            //for (int i = 0; i < 8; i++)
            //{
            //    persons.Add(MockPerson(i));
            //}

            //return persons;

            return _context.Persons.ToList();
        }

        // Método responsável por retornar uma pessoa
        // como esse teste é mockado o retorno está fixo
        public Person FindById(long Id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
            //return new Person() { Id = 1, FirstName = "Fernando", LastName = "Carvalho", Address = "Rua São Paulo, São Caetano do Sul", Gender = "Male" };
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação passada
        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person() { Id = IncrementAndGet(), 
                                  FirstName = "Person Name -" + i.ToString(), 
                                  LastName = "Person LastName -" + i.ToString(), 
                                  Address = "Person Address -" + i.ToString(), 
                                  Gender = "Male" };

        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
