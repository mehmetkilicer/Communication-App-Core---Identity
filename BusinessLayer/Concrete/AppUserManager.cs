using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        ProjeContext context = new ProjeContext();
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TDelete(int id)
        {
            _appUserDal.Delete(id);
        }

        public List<AppUser> TGetAll()
        {
            return _appUserDal.GetAll();
        }

        public List<AppUser> TGetByFilter(Expression<Func<AppUser, bool>> filter)
        {
            return _appUserDal.GetByFilter(filter);
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        //public List<AppUser> TGetUserWithDepartment()
        //{
            
        //    return _appUserDal.GetUserWithDepartment();
        //}

        public void TInsert(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void TUpdate(AppUser entity)
        {
           _appUserDal.Update(entity);
        }
    }
}
