using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class CommentRepository : ICommentsRepository
    {
        readonly private DataContext _context;
        readonly private ITagsRepository _tagsRepository;

        public CommentRepository(DataContext context, ITagsRepository tagsRepository)
        {
            _context = context;
            _tagsRepository = tagsRepository;
        }

        public async Task<Comment> Add(Comment item)
        {
            if(_context.Posts.Where(p => p.Id == item.PostId).FirstOrDefault() == null)
            {
                throw new Exception("Post with this id doesn't exist.");
            }
            ICollection<Tag> tags = new List<Tag>();
            for (int i = 0; i < item.Tags.Count; i++)
            {
                tags.Add(await _tagsRepository.Add(item.Tags.ElementAt(i)));
            }   
            ICollection<UserTaggedComment> users = new List<UserTaggedComment>();
            for(int i = 0; i < item.UserTaggedComment.Count; i++)
            {
                if(_context.Users.SingleOrDefault(u => u.Id == item.UserTaggedComment.ElementAt(i).UserId) != null)
                {
                    users.Add(item.UserTaggedComment.ElementAt(i));
                }
            }
            item.Tags = tags;
            item.UserTaggedComment = users;
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
            return _context.Comments.Include(c => c.Tags).Include(c => c.UserTaggedComment).ToList();
        }

        public ICollection<Comment> GetAllByPostId(int postId)
        {
            return _context.Comments.Where(c => c.PostId == postId).Include(c => c.Tags).Include(c => c.UserTaggedComment).ToList();
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
