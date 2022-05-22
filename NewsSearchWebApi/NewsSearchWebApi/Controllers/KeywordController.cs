using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsSearchWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewsSearchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordController : ControllerBase
    {
        private readonly AppDbContext _context;
        public KeywordController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Keyword> GetAllKeywords()
        {
            var list = _context.Keywords.ToList();
            return list;
        }

        [HttpPost]
        public void CreateKeyword(Keyword item)
        {
            var x = GetAllKeywords().Where(x => x.Word == item.Word).ToList();

            if (x.Count == 0)
            {
                _context.Keywords.Add(item);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteKeyword(int id)
        {
            var deletedKeyword = _context.Keywords.Where(x => x.Id == id).FirstOrDefault();
            _context.Keywords.Remove(deletedKeyword);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateKeyword(int id)
        {
            var updatedKeyword = _context.Keywords.Where(x => x.Id == id).FirstOrDefault();
            _context.Keywords.Update(updatedKeyword);
            _context.SaveChanges();
        }

        [HttpGet("{id}")]
        public Keyword GetKeywordById(int id)
        {
            var getItem = _context.Keywords.Where(x => x.Id == id).FirstOrDefault();
            return getItem;
        }
    }
}
