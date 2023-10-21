using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Identity;

namespace Newsletter.Data
{
    public class NewsletterSeed
    {
        public int id { get; set; }
        public Blob companyImage { get; set; }
        public required string newsTitle { get; set; }
        public int sequentialNumber { get; set; }
        public DateTime date { get; set; }            
        public Article[]? articles { get; set; }
        public bool isActive { get; set; }

    }
}