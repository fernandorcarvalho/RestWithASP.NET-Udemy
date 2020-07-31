using RestWithASP.NETUdemy.Controllers.Model;
using RestWithASP.NETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASP.NETUdemy.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        // Método responsável por criar uma nova pessoa
        // Se tivéssemos um banco de dados esse seria o momento de persistir os dados
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        // Método responsável por deletar o resgistro de uma pessoa a partir do ID
        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }
        
        // Método responsável por retornar todas as pessoas
        // nesta implemtnação os dados estão mockados
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        // Método responsável por retornar uma pessoa
        // como esse teste é mockado o retorno está fixo
        public Person FindById(long Id)
        {
            return _repository.FindById(Id);
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação passada
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
