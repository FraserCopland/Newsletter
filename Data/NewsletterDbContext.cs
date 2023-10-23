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
                entity.HasMany(e => e.Articles).WithOne(e => e.Newsletter).HasForeignKey(e => e.NewsletterId).IsRequired();
                entity.Property(e => e.IsActive).IsRequired();

                entity.HasData(new Newsletter {
                    NewsletterId = 1,
                    NewsTitle = "First Newsletter",
                    SequentialNumber = 1,
                    Date = DateTime.Now,
                    
                    IsActive = true
                });
                entity.HasData(new Newsletter {
                    NewsletterId = 2,
                    NewsTitle = "Second Newsletter",
                    SequentialNumber = 2,
                    Date = DateTime.Now,
                    IsActive = true
                });
                entity.HasData(new Newsletter {
                    NewsletterId = 3,
                    NewsTitle = "Third Newsletter",
                    SequentialNumber = 3,
                    Date = DateTime.Now,
                    IsActive = false
                });
            });

            builder.Entity<Article> (entity => {
                entity.HasKey(e => e.ArticleId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.NewsletterId).IsRequired();
                entity.HasOne(e => e.Newsletter).WithMany(e => e.Articles).HasForeignKey(e => e.NewsletterId).IsRequired();
                entity.HasData(new Article {
                    ArticleId = 1,
                    Title = "First Article",
                    Content = "This is the first article",
                    NewsletterId = 1
                });
                entity.HasData(new Article {
                    ArticleId = 2,
                    Title = "Second Article",
                    Content = "This is the second article",
                    NewsletterId = 1
                });
                entity.HasData(new Article {
                    ArticleId = 3,
                    Title = "Third Article",
                    Content = "This is the third article",
                    NewsletterId = 2
                });
                entity.HasData(new Article {
                    ArticleId = 4,
                    Title = "Fourth Article",
                    Content = "This is the fourth article",
                    NewsletterId = 2
                });
                entity.HasData(new Article {
                    ArticleId = 5,
                    Title = "Fifth Article",
                    Content = "This is the fifth article",
                    NewsletterId = 3
                });
                entity.HasData(new Article {
                    ArticleId = 6,
                    Title = "Sixth Article",
                    Content = "This is the sixth article",
                    NewsletterId = 3
                });
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