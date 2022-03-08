using fakeLook_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Add(T item);
        public ICollection<T> GetAll();
        public Task<T> Edit(T item);
        public T GetById(int id);
        public ICollection<T> GetByPredicate(Func<T, bool> predicate);
    }
    public interface IUserRepository : IRepository<User>
    {

    }
    public interface IPostRepository : IRepository<Post>
    {

    }
}
