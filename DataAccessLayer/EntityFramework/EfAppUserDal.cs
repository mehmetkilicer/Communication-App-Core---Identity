using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        //ProjeContext context = new ProjeContext();
        //public List<AppUser> GetUserWithDepartment()
        //{
        //    var values= context.Users.Include(x=> x.Department).ToList();
        //    return values;
        //}
    }
}
