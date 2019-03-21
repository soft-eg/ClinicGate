
using ClinicGate.Core.Contracts;
using ClinicGate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace ClinicGate.DAL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
       
        public void Delete(string Id)
        {
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
        }

         
        public void Insert(T t)
        {
            dbSet.Add(t);
        }


        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }


        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public async Task<IEnumerable<T>> CollectionAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync();
        }
        public async Task<T> FindByIdAsync(string id)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> AnyAsync(string id)
        {
            return await dbSet.AnyAsync(x => x.Id == id);
        }
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

    

       
    }
}