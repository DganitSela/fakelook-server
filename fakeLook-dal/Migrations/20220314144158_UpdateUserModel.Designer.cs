﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fakeLook_dal.Data;

#nullable disable

namespace fakeLook_dal.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220314144158_UpdateUserModel")]
    partial class UpdateUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CommentTag", b =>
                {
                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("CommentsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("CommentTag");
                });

            modelBuilder.Entity("fakeLook_models.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "comment 1",
                            PostId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "comment 2",
                            PostId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "comment 3",
                            PostId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Content = "comment 4",
                            PostId = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Content = "comment 5",
                            PostId = 1,
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Content = "comment 1",
                            PostId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            Content = "comment 2",
                            PostId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 8,
                            Content = "comment 3",
                            PostId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Content = "comment 4",
                            PostId = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            Content = "comment 5",
                            PostId = 2,
                            UserId = 5
                        },
                        new
                        {
                            Id = 11,
                            Content = "comment 1",
                            PostId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            Content = "comment 2",
                            PostId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 13,
                            Content = "comment 3",
                            PostId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 14,
                            Content = "comment 4",
                            PostId = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 15,
                            Content = "comment 5",
                            PostId = 3,
                            UserId = 5
                        },
                        new
                        {
                            Id = 16,
                            Content = "comment 1",
                            PostId = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 17,
                            Content = "comment 2",
                            PostId = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 18,
                            Content = "comment 3",
                            PostId = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 19,
                            Content = "comment 4",
                            PostId = 4,
                            UserId = 4
                        },
                        new
                        {
                            Id = 20,
                            Content = "comment 5",
                            PostId = 4,
                            UserId = 5
                        },
                        new
                        {
                            Id = 21,
                            Content = "comment 1",
                            PostId = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 22,
                            Content = "comment 2",
                            PostId = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 23,
                            Content = "comment 3",
                            PostId = 5,
                            UserId = 3
                        },
                        new
                        {
                            Id = 24,
                            Content = "comment 4",
                            PostId = 5,
                            UserId = 4
                        },
                        new
                        {
                            Id = 25,
                            Content = "comment 5",
                            PostId = 5,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("fakeLook_models.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            PostId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            PostId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            PostId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            PostId = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            PostId = 1,
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            PostId = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            PostId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            PostId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            PostId = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            IsActive = true,
                            PostId = 2,
                            UserId = 5
                        },
                        new
                        {
                            Id = 11,
                            IsActive = true,
                            PostId = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            IsActive = true,
                            PostId = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 13,
                            IsActive = true,
                            PostId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 14,
                            IsActive = true,
                            PostId = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 15,
                            IsActive = true,
                            PostId = 3,
                            UserId = 5
                        },
                        new
                        {
                            Id = 16,
                            IsActive = true,
                            PostId = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 17,
                            IsActive = true,
                            PostId = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 18,
                            IsActive = true,
                            PostId = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 19,
                            IsActive = true,
                            PostId = 4,
                            UserId = 4
                        },
                        new
                        {
                            Id = 20,
                            IsActive = true,
                            PostId = 4,
                            UserId = 5
                        },
                        new
                        {
                            Id = 21,
                            IsActive = true,
                            PostId = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 22,
                            IsActive = true,
                            PostId = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 23,
                            IsActive = true,
                            PostId = 5,
                            UserId = 3
                        },
                        new
                        {
                            Id = 24,
                            IsActive = true,
                            PostId = 5,
                            UserId = 4
                        },
                        new
                        {
                            Id = 25,
                            IsActive = true,
                            PostId = 5,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("fakeLook_models.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSorce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("X_Position")
                        .HasColumnType("float");

                    b.Property<double>("Y_Position")
                        .HasColumnType("float");

                    b.Property<double>("Z_Position")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1788),
                            Description = "post 1",
                            ImageSorce = "https://s.yimg.com/ny/api/res/1.2/PPu_U6UY8JjEGaR3t4T3wQ--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTcyMDtjZj13ZWJw/https://s.yimg.com/uu/api/res/1.2/Rffcviow.eCHjmEu2msLJg--~B/aD0xNzU3O3c9MjM0MzthcHBpZD15dGFjaHlvbg--/https://media.zenfs.com/en/insider_articles_922/c6ce8d0b9a7b28f9c2dee8171da98b8f",
                            UserId = 1,
                            X_Position = 45.705712122117106,
                            Y_Position = 38.622266450264256,
                            Z_Position = 28.336899149219818
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1834),
                            Description = "post 2",
                            ImageSorce = "https://s.yimg.com/ny/api/res/1.2/PPu_U6UY8JjEGaR3t4T3wQ--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTcyMDtjZj13ZWJw/https://s.yimg.com/uu/api/res/1.2/Rffcviow.eCHjmEu2msLJg--~B/aD0xNzU3O3c9MjM0MzthcHBpZD15dGFjaHlvbg--/https://media.zenfs.com/en/insider_articles_922/c6ce8d0b9a7b28f9c2dee8171da98b8f",
                            UserId = 2,
                            X_Position = 39.023416258127924,
                            Y_Position = 41.129544628942853,
                            Z_Position = 28.695917167550043
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1837),
                            Description = "post 3",
                            ImageSorce = "https://s.yimg.com/ny/api/res/1.2/PPu_U6UY8JjEGaR3t4T3wQ--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTcyMDtjZj13ZWJw/https://s.yimg.com/uu/api/res/1.2/Rffcviow.eCHjmEu2msLJg--~B/aD0xNzU3O3c9MjM0MzthcHBpZD15dGFjaHlvbg--/https://media.zenfs.com/en/insider_articles_922/c6ce8d0b9a7b28f9c2dee8171da98b8f",
                            UserId = 3,
                            X_Position = 35.084934589738168,
                            Y_Position = 14.162629815412735,
                            Z_Position = 34.480150819152435
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1839),
                            Description = "post 4",
                            ImageSorce = "https://s.yimg.com/ny/api/res/1.2/PPu_U6UY8JjEGaR3t4T3wQ--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTcyMDtjZj13ZWJw/https://s.yimg.com/uu/api/res/1.2/Rffcviow.eCHjmEu2msLJg--~B/aD0xNzU3O3c9MjM0MzthcHBpZD15dGFjaHlvbg--/https://media.zenfs.com/en/insider_articles_922/c6ce8d0b9a7b28f9c2dee8171da98b8f",
                            UserId = 4,
                            X_Position = 29.457071865358099,
                            Y_Position = 0.92772590207340633,
                            Z_Position = 37.58119120199197
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2022, 3, 14, 16, 41, 58, 334, DateTimeKind.Local).AddTicks(1842),
                            Description = "post 5",
                            ImageSorce = "https://s.yimg.com/ny/api/res/1.2/PPu_U6UY8JjEGaR3t4T3wQ--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTcyMDtjZj13ZWJw/https://s.yimg.com/uu/api/res/1.2/Rffcviow.eCHjmEu2msLJg--~B/aD0xNzU3O3c9MjM0MzthcHBpZD15dGFjaHlvbg--/https://media.zenfs.com/en/insider_articles_922/c6ce8d0b9a7b28f9c2dee8171da98b8f",
                            UserId = 5,
                            X_Position = 8.5120322719778709,
                            Y_Position = 10.658921742199279,
                            Z_Position = 46.40667323190565
                        });
                });

            modelBuilder.Entity("fakeLook_models.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "tag 1"
                        },
                        new
                        {
                            Id = 2,
                            Content = "tag 2"
                        },
                        new
                        {
                            Id = 3,
                            Content = "tag 3"
                        },
                        new
                        {
                            Id = 4,
                            Content = "tag 4"
                        },
                        new
                        {
                            Id = 5,
                            Content = "tag 5"
                        });
                });

            modelBuilder.Entity("fakeLook_models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "some adress",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "user 1",
                            Password = "-1024888312"
                        },
                        new
                        {
                            Id = 2,
                            Address = "some adress",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "user 2",
                            Password = "-1024888312"
                        },
                        new
                        {
                            Id = 3,
                            Address = "some adress",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "user 3",
                            Password = "-1024888312"
                        },
                        new
                        {
                            Id = 4,
                            Address = "some adress",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "user 4",
                            Password = "-1024888312"
                        },
                        new
                        {
                            Id = 5,
                            Address = "some adress",
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "user 5",
                            Password = "-1024888312"
                        });
                });

            modelBuilder.Entity("fakeLook_models.Models.UserTaggedComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTaggedComments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentId = 19,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            CommentId = 15,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            CommentId = 9,
                            UserId = 5
                        },
                        new
                        {
                            Id = 4,
                            CommentId = 14,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            CommentId = 9,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            CommentId = 12,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            CommentId = 2,
                            UserId = 5
                        },
                        new
                        {
                            Id = 8,
                            CommentId = 18,
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            CommentId = 18,
                            UserId = 3
                        },
                        new
                        {
                            Id = 10,
                            CommentId = 11,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("fakeLook_models.Models.UserTaggedPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTaggedPosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            PostId = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            PostId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            PostId = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            PostId = 1,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("PostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("CommentTag", b =>
                {
                    b.HasOne("fakeLook_models.Models.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("fakeLook_models.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("fakeLook_models.Models.Comment", b =>
                {
                    b.HasOne("fakeLook_models.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("fakeLook_models.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fakeLook_models.Models.Like", b =>
                {
                    b.HasOne("fakeLook_models.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("fakeLook_models.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fakeLook_models.Models.Post", b =>
                {
                    b.HasOne("fakeLook_models.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("fakeLook_models.Models.UserTaggedComment", b =>
                {
                    b.HasOne("fakeLook_models.Models.Comment", "Comment")
                        .WithMany("UserTaggedComment")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("fakeLook_models.Models.User", "User")
                        .WithMany("UserTaggedComment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("fakeLook_models.Models.UserTaggedPost", b =>
                {
                    b.HasOne("fakeLook_models.Models.Post", "Post")
                        .WithMany("UserTaggedPost")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("fakeLook_models.Models.User", "User")
                        .WithMany("UserTaggedPost")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("fakeLook_models.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("fakeLook_models.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("fakeLook_models.Models.Comment", b =>
                {
                    b.Navigation("UserTaggedComment");
                });

            modelBuilder.Entity("fakeLook_models.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("UserTaggedPost");
                });

            modelBuilder.Entity("fakeLook_models.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("UserTaggedComment");

                    b.Navigation("UserTaggedPost");
                });
#pragma warning restore 612, 618
        }
    }
}
