
using ClinicGate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClinicGate.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {

        void Delete(string Id);
        void Insert(T t);
        void Update(T t);
        T Find(string Id);

        Task<IEnumerable<T>> CollectionAsync();

        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> FindByIdAsync(string id);
        Task<bool> AnyAsync(string id);
        Task CommitAsync();

    }
}