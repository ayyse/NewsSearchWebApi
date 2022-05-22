using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsSearchWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewsSearchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void CreateNews(News item)
        {
            var x = GetAllNews().Where(x => x.Url == item.Url).ToList();

            if (x.Count == 0)
            {
                var lastItem = GetAllNews().LastOrDefault();
                if (lastItem.PublishedAt < item.PublishedAt)
                {
                    _context.News.Add(item);
                    _context.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public void DeleteNews(int id)
        {
            var deletedNew = _context.News.Where(x => x.Id == id).FirstOrDefault();
            _context.News.Remove(deletedNew);
            _context.SaveChanges();
        }

        [HttpGet]
        public List<News> GetAllNews()
        {
            var list = _context.News.ToList();
            return list;
        }

        [HttpGet("{id}")]
        public News GetNewsById(int id)
        {
            var getItem = _context.News.Where(x => x.Id == id).FirstOrDefault();
            return getItem;
        }
    }
}
