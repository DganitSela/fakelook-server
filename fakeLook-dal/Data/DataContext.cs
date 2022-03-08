using fakeLook_models.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace fakeLook_dal.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<UserTaggedComment> UserTaggedComments { get; set; }
        public DbSet<UserTaggedPost> UserTaggedPosts { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Model Mapping
            //users
            modelBuilder.Entity<User>().HasMany(u => u.Comments).WithOne(c => c.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(u => u.Posts).WithOne(p => p.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(u => u.Likes).WithOne(l => l.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(u => u.UserTaggedComment).WithOne(utc => utc.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(u => u.UserTaggedPost).WithOne(utp => utp.User).OnDelete(DeleteBehavior.NoAction);
            ;
            //posts
            modelBuilder.Entity<Post>().HasMany(p => p.Likes).WithOne(l => l.Post).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>().HasMany(p => p.Comments).WithOne(c => c.Post).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>().HasMany(p => p.UserTaggedPost).WithOne(utp => utp.Post).OnDelete(DeleteBehavior.NoAction);
            ;
            //comment
            modelBuilder.Entity<Comment>().HasMany(c => c.UserTaggedComment).WithOne(utc => utc.Comment).OnDelete(DeleteBehavior.NoAction);
            #endregion
            //simple seed
            SeedDb(modelBuilder);
        }
        private void SeedDb(ModelBuilder modelBuilder)
        {
            const int amount = 5;
            AddUsers();
            AddPosts();
            AddComment();
            AddLike();
            AddTags();
            AddUserTaggedPosts();
            AddUserTaggedComments();


            void AddUsers()
            {
                var name = "user ";
                var address = "some adress";
                var password = "12345".GetHashCode().ToString();
                var users = new User[amount];
                for (int i = 0; i < amount; i++)
                {
                    users[i] = new User() { Id = i + 1, Address = address, Name = name + (i + 1).ToString(), Password = password };
                }
                SeedDb(users);
            }
            void AddPosts()
            {
                var random = new Random();
                var src = "https://s.yimg.com/ny/api/res/1.2/PPu_U6UY8JjEGaR3t4T3wQ--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTcyMDtjZj13ZWJw/https://s.yimg.com/uu/api/res/1.2/Rffcviow.eCHjmEu2msLJg--~B/aD0xNzU3O3c9MjM0MzthcHBpZD15dGFjaHlvbg--/https://media.zenfs.com/en/insider_articles_922/c6ce8d0b9a7b28f9c2dee8171da98b8f";
                var description = "post ";
                var posts = new Post[amount];
                for (int i = 0; i < amount; i++)
                {
                    posts[i] = new Post()
                    {
                        Id = i + 1,
                        UserId = i + 1,
                        ImageSorce = src,
                        Description = description + (i + 1).ToString(),
                        Date = DateTime.Now,
                        X_Position = random.NextDouble() * 50,
                        Y_Position = random.NextDouble() * 50,
                        Z_Position = random.NextDouble() * 50,
                    };
                }
                SeedDb(posts);
            }
            void AddComment()
            {
                var content = "comment ";
                var comments = new Comment[amount * amount];
                for (int i = 0; i < amount; i++)
                {
                    for (int j = 0; j < amount; j++)
                    {
                        comments[i * amount + j] = new Comment()
                        {
                            Id = i * amount + j + 1,
                            Content = content + (j + 1).ToString(),
                            UserId = j + 1,
                            PostId = i + 1,
                        };
                    }

                }
                SeedDb(comments);
            }
            void AddLike()
            {
                var likes = new Like[amount * amount];
                for (int i = 0; i < amount; i++)
                {
                    for (int j = 0; j < amount; j++)
                    {
                        likes[i * amount + j] = new Like()
                        {
                            Id = i * amount + j + 1,
                            IsActive = true,
                            UserId = j + 1,
                            PostId = i + 1,
                        };
                    }

                }
                SeedDb(likes);
            }
            void AddTags()
            {
                // didnt seeded the relationships only the data
                var content = "tag ";
                var tags = new Tag[amount];
                for (int i = 0; i < amount; i++)
                {
                    tags[i] = new Tag()
                    {
                        Id = i + 1,
                        Content = content + (i + 1).ToString(),
                    };
                }
                SeedDb(tags);
            }
            void AddUserTaggedPosts()
            {
                var userTagged = new UserTaggedPost[amount];
                for (int i = 0; i < amount; i++)
                {
                    userTagged[i] = new UserTaggedPost() { Id = i + 1, UserId = i + 1, PostId = amount - i };
                }
                SeedDb(userTagged);
            }
            void AddUserTaggedComments()
            {
                var userTagged = new UserTaggedComment[amount * 2];
                var random = new Random();
                for (int i = 0; i < amount * 2; i++)
                {
                    userTagged[i] = new UserTaggedComment() { Id = i + 1, UserId = random.Next(1,amount+1), CommentId = random.Next(1, amount * amount) };
                }
                SeedDb(userTagged);
            }
            void SeedDb<T>(T[] data) where T : class
            {
                modelBuilder.Entity<T>().HasData(data);
            }
        }

    }
}
