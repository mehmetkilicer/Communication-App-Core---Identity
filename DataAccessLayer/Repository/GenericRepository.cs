using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
       ProjeContext _projeContext = new ProjeContext();
        public void Delete(int id)
        {
            var values = _projeContext.Set<T>().Find(id);
            _projeContext.Set<T>().Remove(values);
            _projeContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _projeContext.Set<T>().ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _projeContext.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return _projeContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _projeContext.Set<T>().Add(entity);
            _projeContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _projeContext.Set<T>().Update(entity);
            _projeContext.SaveChanges();
        }
    }
}
