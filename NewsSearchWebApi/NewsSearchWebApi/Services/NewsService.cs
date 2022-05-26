using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsSearchWebApi.Interfaces;
using NewsSearchWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsSearchWebApi.Services
{
    public class NewsService : INewsService
    {
        private readonly AppDbContext _context;
        private readonly IKeywordService _keywordService;
        public NewsService(AppDbContext context, IKeywordService keywordService)
        {
            _context = context;
            _keywordService = keywordService;
        }
        public void CreateNews(News item)
        {
            var newsApiClient = new NewsApiClient("fa7766431fda403baddf546cfb2e8ebb");

            var articleResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Türkiye",
                Language = Languages.TR,
                SortBy = SortBys.PublishedAt,
                From = new DateTime(2022, 5, 20)
            });

            var sortedList = articleResponse.Articles.Reverse<Article>();

            foreach (var response in sortedList)
            {
                var keywords = _keywordService.GetAllKeywords();

                foreach (var keyword in keywords)
                {
                    var lowerResponse = response.Title.ToLower();
                    var lowerKeyword = keyword.Word.ToString().ToLower();

                    if (lowerResponse.Contains(lowerKeyword) == true)
                    {

                        item.KeywordId = keyword.Id;
                        item.Word = keyword.Word;

                        item.Author = response.Author;
                        item.Title = response.Title;
                        item.Description = response.Description;
                        item.Url = response.Url;
                        item.PublishedAt = (DateTime)response.PublishedAt;
                        item.Content = response.Content;

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
                }
            }
        }

        public void DeleteNews(int id)
        {
            var deletedNew = _context.News.Where(x => x.Id == id).FirstOrDefault();
            _context.News.Remove(deletedNew);
            _context.SaveChanges();
        }

        public List<News> GetAllNews()
        {
            var list = _context.News.ToList();
            return list;
        }

        public News GetNewsById(int id)
        {
            var getItem = _context.News.Where(x => x.Id == id).FirstOrDefault();
            return getItem;
        }
    }
}
