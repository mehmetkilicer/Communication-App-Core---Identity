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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        ProjeContext context = new ProjeContext();
        public List<Message> GetMessageWithUsers()
        {
            var values = context.Messages.Include(x=>x.SenderUser).ToList();
            return values;
        }
    }
}
