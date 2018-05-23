using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsenetApi.Models;

namespace UsenetApi.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly UsenetContext _context;

        public ArticlesController(UsenetContext context)
        {
            _context = context;

            if (_context.Articles.Count() == 0)
            {
                _context.Articles.Add(new Article { GroupId = 1, Subject = "foo" });
                _context.Articles.Add(new Article { GroupId = 1, Subject = "bar" });
                _context.SaveChanges();
            }
        }     

        [HttpGet]
        public ICollection<Article> GetAll()
        {
            return _context.Articles.ToList();
        }

        [HttpGet("{id}", Name = "GetArticle")]
        public IActionResult GetById(int id)
        {
            var item = _context.Articles.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }  
    }
}