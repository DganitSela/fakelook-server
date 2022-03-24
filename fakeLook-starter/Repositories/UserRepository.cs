using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

    public async Task<User> Add(User item)
        {
            // TODO: get better hashcode algorithm for encrypted password
            //item.Password = item.Password.GetHashCode().ToString();
            if(_context.Users.SingleOrDefault(user => user.Email.Equals(item.Email)) != null)
            {
                throw new Exception("User with this email is already exists.");
            }
            else if (_context.Users.SingleOrDefault(user => user.UserName.Equals(item.UserName)) != null)
            {
                throw new Exception("User with this username is already exists.");
            }
            var res = _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;

        }

        public async Task<User> Edit(User item)
        {
            // TODO: get better hashcode algorithm for encrypted password
            //item.Password = item.Password.GetHashCode().ToString();
            var existUser = _context.Users.Where(user => user.UserName.Equals(item.UserName)).FirstOrDefault();
            if(existUser == null)
            {
                throw new Exception("User with this username doesn't exists.");
            } else
            {
                existUser.Password = item.Password;
                var res = _context.Users.Update(existUser);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            return _context.Users.Where(predicate).ToList();
        }

        public User GetUser(User user)
        {
            // TODO: get better hashcode algorithm for encrypted password
            //user.Password = user.Password.GetHashCode().ToString();
            return _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).SingleOrDefault();
        }

        // Function that creates and returns a dictionary with pair of user id and user names.
        public Dictionary<int, string> GetUserNames()
        {
            Dictionary<int, string> usersDictionary = new Dictionary<int, string>();
            var users = GetAll();
            foreach (var user in users)
            {
                usersDictionary.Add(user.Id, user.UserName);
            }
            return usersDictionary;
        }
    }
}
