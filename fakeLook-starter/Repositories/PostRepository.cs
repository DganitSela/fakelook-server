using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Controllers;
using fakeLook_starter.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class PostRepository : IPostRepository
    {
        readonly private DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Post> Add(Post item)
        {
            List<Tag> tags = new List<Tag>();
            if (item.Tags != null)
            {
                tags = item.Tags.ToList();
                item.Tags.Clear();
            }
            
            var res = _context.Posts.Add(item);
            await _context.SaveChangesAsync();
            foreach (var tag in tags)
            {
                res.Entity.Tags.Add(tag);
            }
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Post> Edit(Post item)
        {
            var res = _context.Posts.Update(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public ICollection<Post> GetAll()
        {
            return _context.Posts.Include(p => p.Comments).Include(p => p.Likes).OrderByDescending(p => p.Date).ToList();
        }

        public ICollection<Post> GetAll(PostParameters postParameters)
        {
            //var posts;
            return _context.Posts.Where(p => p.Date <= postParameters.MaxDate && p.Date >= postParameters.MinDate).OrderByDescending(p => p.Date).ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Post> GetByPredicate(Func<Post,bool> predicate)
        {
            return _context.Posts.Where(predicate).ToList();
        }
    }
}
