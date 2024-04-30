using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
         IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void TDelete(int id)
        {
           _departmentDal.Delete(id);
        }

        public List<Department> TGetAll()
        {
            return _departmentDal.GetAll();
        }

        public List<Department> TGetByFilter(Expression<Func<Department, bool>> filter)
        {
            return _departmentDal.GetByFilter(filter);
        }

        public Department TGetById(int id)
        {
           return _departmentDal.GetById(id);
        }

        public void TInsert(Department entity)
        {
           _departmentDal.Insert(entity);
        }

        public void TUpdate(Department entity)
        {
           _departmentDal.Update(entity);
        }
    }
}
