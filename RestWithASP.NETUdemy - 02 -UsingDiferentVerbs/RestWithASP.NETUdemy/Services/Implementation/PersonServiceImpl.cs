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
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));

            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }_context.SaveChanges();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // Método responsável por retornar todas as pessoas
        // nesta implemtnação os dados estão mockados
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        // Método responsável por retornar uma pessoa
        // como esse teste é mockado o retorno está fixo
        public Person FindById(long Id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação passada
        public Person Update(Person person)
        {
            // Verifica se a pessoa nâo existe no banco de dados.
            if (!Exists(person.Id))
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        private bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
