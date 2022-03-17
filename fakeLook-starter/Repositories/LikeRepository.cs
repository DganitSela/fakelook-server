using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class LikeRepository : ILikesRepository
    {
        readonly private DataContext _context;
        public LikeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Like> Add(Like item)
        {
            var res = _context.Likes.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Like> Edit(Like item)
        {
            var existLike = _context.Likes.Where(like => like.Id == item.Id).FirstOrDefault();
            if (existLike == null)
            {
                throw new Exception("Like with this id doesn't exists.");
            } else if (existLike.UserId != item.UserId)
            {
                throw new Exception("This like not connected to this user.");
            }
            else
            {
                existLike.IsActive = item.IsActive;
                var res = _context.Likes.Update(existLike);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
        }

        public ICollection<Like> GetAll()
        {
            return _context.Likes.ToList();
        }

        public ICollection<Like> GetAllByPostId(int postId)
        {
            return _context.Likes.Where(l => l.PostId == postId).ToList();
        }

        public Like GetById(int id)
        {
            return _context.Likes.SingleOrDefault(l => l.Id == id);
        }

        public ICollection<Like> GetByPredicate(Func<Like, bool> predicate)
        {
            return _context.Likes.Where(predicate).ToList();
        }
    }
}
