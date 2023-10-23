using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Newsletter.Data
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey ("NewsletterId")]
        public int NewsletterId { get; set; }
        public Newsletter Newsletter { get; set; }
    }
}