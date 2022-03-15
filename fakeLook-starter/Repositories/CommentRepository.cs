using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class CommentRepository : ICommentsRepository
    {
        readonly private DataContext _context;
        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Comment> Add(Comment item)
        {
            var res = _context.Comments.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Comment> Edit(Comment item)
        {
            var res = _context.Comments.Update(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public ICollection<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public ICollection<Comment> GetAllByPostId(int postId)
        {
            return _context.Comments.Where(c => c.PostId == postId).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Comment> GetByPredicate(Func<Comment, bool> predicate)
        {
            return _context.Comments.Where(predicate).ToList();
        }
    }
}
