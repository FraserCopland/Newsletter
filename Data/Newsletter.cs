using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Identity;

namespace Newsletter.Data
{
    public class Newsletter
    {
        public int NewsletterId { get; set; }
        public string NewsTitle { get; set; }
        public int SequentialNumber { get; set; }
        public DateTime Date { get; set; }            
        public Article[]? Articles { get; set; }
        public bool IsActive { get; set; }

    }
}