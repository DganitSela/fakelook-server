using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class UserTaggedPostRepository : IUserTaggedPostRepository
    {
        private readonly DataContext _context;

        public UserTaggedPostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserTaggedPost> Add(UserTaggedPost item)
        {
            var res = _context.UserTaggedPosts.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public void Delete(int id)
        {
            var userTaggedPost = _context.UserTaggedPosts.SingleOrDefault(u => u.Id == id);
            if(userTaggedPost != null)
            {
                _context.UserTaggedPosts.Remove(userTaggedPost);
            }
        }

        public async Task<UserTaggedPost> Edit(UserTaggedPost item)
        {
            return null;
        }

        public ICollection<UserTaggedPost> GetAll()
        {
            return _context.UserTaggedPosts.ToList();
        }

        public UserTaggedPost GetById(int id)
        {
            return _context.UserTaggedPosts.SingleOrDefault(u => u.Id == id);
        }

        public ICollection<UserTaggedPost> GetByPredicate(Func<UserTaggedPost, bool> predicate)
        {
            return _context.UserTaggedPosts.Where(predicate).ToList();
        }
    }
}
