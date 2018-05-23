using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsenetApi.Models;

namespace UsenetApi.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly UsenetDbContext _context;

        public GroupsController(UsenetDbContext context)
        {
            _context = context;

            if (_context.Groups.Count() == 0)
            {
                _context.SaveChanges();
            }
        }     

        [HttpGet]
        public List<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        [HttpGet("{id}", Name = "GetGroup")]
        public IActionResult GetById(long id)
        {
            var item = _context.Groups.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }  
    }
}