using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Newsletter.Data
{
    public class Article
    {
        public int id { get; set; }
        public required string title { get; set; }
        public required string content { get; set; }
        public Blob image { get; set; }

    }
}