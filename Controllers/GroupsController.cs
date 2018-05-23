using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsenetApi.Models;

namespace UsenetApi.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly UsenetContext _context;

        public GroupsController(UsenetContext context)
        {
            _context = context;

            if (_context.Groups.Count() == 0)
            {
                _context.Groups.Add(new Group { Name = "Group1" });
                _context.Groups.Add(new Group { Name = "Group2" });
                _context.SaveChanges();
            }
        }     

        [HttpGet]
        public List<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        [HttpGet("{id}", Name = "GetGroup")]
        public IActionResult GetById(int id)
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