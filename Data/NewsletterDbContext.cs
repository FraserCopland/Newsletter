using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newsletter.Data.Migrations;

namespace Newsletter.Data
{
    public class NewsletterDbContext : DbContext
    {
        public NewsletterDbContext(DbContextOptions<NewsletterDbContext> options) : base(options) { }
        public DbSet<NewsletterSeed> NewsletterSeeds { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<NewsletterSeed> (entity => {
                entity.HasKey(e => e.id);
                entity.Property(e => e.companyImage).IsRequired();
                entity.Property(e => e.sequentialNumber).IsRequired();
                entity.Property(e => e.newsTitle).IsRequired();
                entity.Property(e => e.date).IsRequired();
                entity.HasMany(e => e.articles).WithOne().IsRequired();
                entity.Property(e => e.isActive).IsRequired();

                entity.HasData(new NewsletterSeed {
                    id = 1,
                    companyImage = new Blob(),
                    newsTitle = "First Newsletter",
                    sequentialNumber = 1,
                    date = DateTime.Now,
                    articles = new Article[] {
                        new Article {
                            id = 1,
                            title = "First Article",
                            content = "This is the first article",
                            image = new Blob()
                        },
                        new Article {
                            id = 2,
                            title = "Second Article",
                            content = "This is the second article",
                            image = new Blob()
                        },
                        new Article {
                            id = 3,
                            title = "Third Article",
                            content = "This is the third article",
                            image = new Blob()
                        }
                    },
                    isActive = true
                });

                entity.HasData(new NewsletterSeed {
                    id = 2,
                    companyImage = new Blob(),
                    newsTitle = "Second Newsletter",
                    sequentialNumber = 2,
                    date = DateTime.Now,
                    articles = new Article[] {
                        new Article {
                            id = 4,
                            title = "First Article",
                            content = "This is the first article",
                            image = new Blob()
                        },
                        new Article {
                            id = 5,
                            title = "Second Article",
                            content = "This is the second article",
                            image = new Blob()
                        },
                        new Article {
                            id = 6,
                            title = "Third Article",
                            content = "This is the third article",
                            image = new Blob()
                        }
                    },
                    isActive = true
                });

                entity.HasData(new NewsletterSeed {
                    id = 3,
                    companyImage = new Blob(),
                    newsTitle = "Third Newsletter",
                    sequentialNumber = 3,
                    date = DateTime.Now,
                    articles = new Article[] {
                        new Article {
                            id = 7,
                            title = "First Article",
                            content = "This is the first article",
                            image = new Blob()
                        },
                        new Article {
                            id = 8,
                            title = "Second Article",
                            content = "This is the second article",
                            image = new Blob()
                        },
                        new Article {
                            id = 9,
                            title = "Third Article",
                            content = "This is the third article",
                            image = new Blob()
                        }
                    },
                    isActive = false
                });
            });

            builder.Entity<Article> (entity => {
                entity.HasKey(e => e.id);
                entity.Property(e => e.title).IsRequired();
                entity.Property(e => e.content).IsRequired();
                entity.Property(e => e.image);
            });

            builder.Entity<UserData>(entity => {
                entity.HasKey(e => e.id);
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.password).IsRequired();

                entity.HasData(new UserData {
                    id = 1,
                    email = "aa@aa.aa",
                    password = "P@ssw0rd"
                });
            });


    }
    }
}