using System;
using System.Collections.Generic;

namespace UsenetApi.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Subject { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}