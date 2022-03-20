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
        readonly private ITagsRepository _tagsRepository;

        public PostRepository(DataContext context, ITagsRepository tagsRepository)
        {
            _context = context;
            _tagsRepository = tagsRepository;
        }

        public async Task<Post> Add(Post item)
        {
            ICollection<Tag> tags = new List<Tag>();
            for(int i = 0; i < item.Tags.Count; i++)
            {
                tags.Add(await _tagsRepository.Add(item.Tags.ElementAt(i)));
            }
            item.Tags = tags;
            var res = _context.Posts.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Post> Edit(Post item)
        {
            ICollection<Tag> tags = new List<Tag>();
            var existPost = _context.Posts.Where(post => post.Id == item.Id).Include(post => post.Tags).FirstOrDefault();
            if(existPost == null)
            {
                throw new Exception("Post with this id doesn't exists.");
            }
            for (int i = 0; i < item.Tags.Count; i++)
            {
                tags.Add(await _tagsRepository.Add(item.Tags.ElementAt(i)));
            }
            existPost.Description = item.Description;
            existPost.Tags = tags;
            var res = _context.Posts.Update(existPost);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public ICollection<Post> GetAll()
        {
            return _context.Posts.Include(p => p.Comments).Include(p => p.Likes).OrderByDescending(p => p.Date).ToList();
        }

        public ICollection<Post> GetAll(PostParameters postParameters)
        {
            return GetByPredicate(p =>
            {
                bool date = p.Date <= postParameters.MaxDate && p.Date >= postParameters.MinDate;
                bool publishers = postParameters.Publishers.Count() > 0 ? postParameters.Publishers.Contains(p.UserId) : true;
                bool tags = postParameters.Tags.Count() > 0 ? CheckIfContainsTag(p, postParameters.Tags) : true;
                bool taggedUsers = postParameters.TaggedUsers.Count() > 0 ? CheckIfContainsTaggedUser(p, postParameters.TaggedUsers) : true;
                return date && publishers && tags && taggedUsers;
            });
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Post> GetByPredicate(Func<Post,bool> predicate)
        {
            return _context.Posts.Include(p => p.Tags).Include(p => p.UserTaggedPost).Where(predicate).ToList();
        }

        private bool CheckIfContainsTag(Post post, List<string> tags)
        {
            foreach(var tag in post.Tags)
            {
                if (tags.Contains(tag.Content))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfContainsTaggedUser(Post post, List<int> taggedUsers)
        {
            foreach(var taggedUser in post.UserTaggedPost)
            {
                if (taggedUsers.Contains(taggedUser.UserId))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
