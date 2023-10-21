using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Newsletter.Data
{
    public class NewsletterDbContext : DbContext
    {
        public NewsletterDbContext(DbContextOptions<NewsletterDbContext> options) : base(options) { }
        public DbSet<Newsletter> Newsletters { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Newsletter> (entity => {
                entity.HasKey(e => e.NewsletterId);
                entity.Property(e => e.SequentialNumber).IsRequired();
                entity.Property(e => e.NewsTitle).IsRequired();
                entity.Property(e => e.Date).IsRequired();
                entity.HasMany(e => e.Articles).WithOne().IsRequired();
                entity.Property(e => e.IsActive).IsRequired();

                entity.HasData(new Newsletter {
                    NewsletterId = 1,
                    NewsTitle = "First Newsletter",
                    SequentialNumber = 1,
                    Date = DateTime.Now,
                    Articles = new Article[] {
                        new Article {
                            ArticleId = 1,
                            Title = "First Article",
                            Content = "This is the first article"
                        },
                        new Article {
                            ArticleId = 2,
                            Title = "Second Article",
                            Content = "This is the second article"
                        }
                    },
                    IsActive = true
                });

                entity.HasData(new Newsletter {
                    NewsletterId = 2,
                    NewsTitle = "Second Newsletter",
                    SequentialNumber = 2,
                    Date = DateTime.Now,
                    Articles = new Article[] {
                        new Article {
                            ArticleId = 3,
                            Title = "First Article",
                            Content = "This is the first article"
                        },
                        new Article {
                            ArticleId = 4,
                            Title = "Second Article",
                            Content = "This is the second article"
                        }
                    },
                    IsActive = true
                });

                entity.HasData(new Newsletter {
                    NewsletterId = 3,
                    NewsTitle = "Third Newsletter",
                    SequentialNumber = 3,
                    Date = DateTime.Now,
                    Articles = new Article[] {
                        new Article {
                            ArticleId = 5,
                            Title = "First Article",
                            Content = "This is the first article"
                        },
                        new Article {
                            ArticleId = 6,
                            Title = "Second Article",
                            Content = "This is the second article"
                        }
                    },
                    IsActive = false
                });
            });

            builder.Entity<Article> (entity => {
                entity.HasKey(e => e.ArticleId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Content).IsRequired();
            });

            builder.Entity<UserData>(entity => {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();

                entity.HasData(new UserData {
                    UserId = 1,
                    Email = "aa@aa.aa",
                    Password = "P@ssw0rd"
                });
            });


    }
    }
}