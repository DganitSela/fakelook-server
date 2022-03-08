using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeLook_models.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        /* EF Relations */
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<UserTaggedComment> UserTaggedComment { get; set; }
    }
}
