using MovieClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Data
{
    public class Repository<T> where T : class
    {
        MovieClubContext ctx;

        public Repository(MovieClubContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public T FindById(string id)
        {
            return null;
            //return ctx.Set<T>().First(t => t. == id);
        }
    }
}
