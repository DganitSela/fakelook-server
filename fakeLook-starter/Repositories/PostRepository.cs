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
        readonly private IUserTaggedPostRepository _userTaggedPostRepository;

        public PostRepository(DataContext context, ITagsRepository tagsRepository, IUserTaggedPostRepository userTaggedPostRepository)
        {
            _context = context;
            _tagsRepository = tagsRepository;
            _userTaggedPostRepository = userTaggedPostRepository;
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
            var existPost = _context.Posts.Where(post => post.Id == item.Id).Include(post => post.Tags).Include(p => p.UserTaggedPost).FirstOrDefault();
            if(existPost == null)
            {
                throw new Exception("Post with this id doesn't exists.");
            }
            if(item.Tags != null)
            {
                ICollection<Tag> tags = new List<Tag>();
                for (int i = 0; i < item.Tags.Count; i++)
                {
                    tags.Add(await _tagsRepository.Add(item.Tags.ElementAt(i)));
                }
                existPost.Tags = tags;
            }
            existPost.Description = item.Description;
            existPost.ImageSorce = item.ImageSorce;
            foreach(var userTaggedPost in existPost.UserTaggedPost)
            {
                _userTaggedPostRepository.Delete(userTaggedPost.Id);
            }
            if(item.UserTaggedPost != null)
            {
                existPost.UserTaggedPost = item.UserTaggedPost;
            }
            var res = _context.Posts.Update(existPost);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public ICollection<Post> GetAll()
        {
            return _context.Posts.Include(p => p.Comments).Include(p => p.Likes).Include(p => p.Tags).Include(p => p.UserTaggedPost).OrderByDescending(p => p.Date).ToList();
        }

        public ICollection<Post> GetAll(PostParameters postParameters)
        {
            return GetByPredicate(p =>
            {
                bool date = p.Date.Date <= postParameters.MaxDate && p.Date.Date >= postParameters.MinDate;
                bool publishers = postParameters.Publishers.Count() > 0 ? postParameters.Publishers.Contains(p.UserId) : true;
                bool tags = postParameters.Tags.Count() > 0 ? CheckIfContainsTag(p, postParameters.Tags) : true;
                bool taggedUsers = postParameters.TaggedUsers.Count() > 0 ? CheckIfContainsTaggedUser(p, postParameters.TaggedUsers) : true;
                return date && publishers && tags && taggedUsers;
            });
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id).Include(p => p.Comments).Include(p => p.Likes).Include(p => p.Tags).Include(p => p.UserTaggedPost).FirstOrDefault();
        }

        public ICollection<Post> GetByPredicate(Func<Post,bool> predicate)
        {
            return _context.Posts.Include(p => p.Comments).Include(p => p.Likes).Include(p => p.Tags).Include(p => p.UserTaggedPost).Where(predicate).OrderByDescending(p => p.Date).ToList();
        }

        // Function that gets post and list of tags and check if the list contains one of the tags
        // that tagged in the post.
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

        // Function that gets post and list of users id and check if the list contains one of the
        // users that tagged in the post.
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
