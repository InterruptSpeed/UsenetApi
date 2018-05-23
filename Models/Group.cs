using System;
using System.Collections.Generic;

namespace UsenetApi.Models
{
    public class Group
    {
        public Group() {
            Articles = new List<Article>();
        }
        
        public int GroupId { get; set; }
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}