using Microsoft.EntityFrameworkCore;
using RestWithASP.NETUdemy.Model.Base;
using RestWithASP.NETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP.NETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(long id)
        {
            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            // Verifica se o registro nâo existe no banco de dados.
            if (!Exists(item.Id)) return null;

            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
