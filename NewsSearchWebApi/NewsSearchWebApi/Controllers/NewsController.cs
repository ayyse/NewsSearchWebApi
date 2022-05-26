using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsSearchWebApi.Interfaces;
using NewsSearchWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsSearchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IKeywordService _keywordService;
        private readonly INewsService _newsService;
        public NewsController(AppDbContext context, INewsService newsService, IKeywordService keywordService)
        {
            _context = context;
            _keywordService = keywordService;
            _newsService = newsService;
        }

        [HttpPost]
        public void CreateNews(News item)
        {
            _newsService.CreateNews(item);
        }

        [HttpDelete("{id}")]
        public void DeleteNews(int id)
        {
            _newsService.DeleteNews(id);
        }

        [HttpGet]
        public List<News> GetAllNews()
        {
            var newsList = _newsService.GetAllNews();
            return newsList;
        }

        [HttpGet("{id}")]
        public News GetNewsById(int id)
        {
            var news = _newsService.GetNewsById(id);
            return news;
        }
    }
}
