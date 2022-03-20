using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class TagRepository : ITagsRepository
    {
        readonly private DataContext _context;
        public TagRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Tag> Add(Tag item)
        {
            var tag = _context.Tags.SingleOrDefault(t => t.Content.Equals(item.Content));
            if(tag == null)
            {
                var res = _context.Tags.Add(item);
                await _context.SaveChangesAsync();
                return res.Entity;
            }
            return tag;
        }

        public async Task<Tag> Edit(Tag item)
        {
            // TODO: what to do here?
            return item;
        }

        public ICollection<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public Tag GetById(int id)
        {
            return _context.Tags.SingleOrDefault(t => t.Id == id);
        }

        public ICollection<Tag> GetByPredicate(Func<Tag, bool> predicate)
        {
            return _context.Tags.Where(predicate).ToList();
        }
    }
}
