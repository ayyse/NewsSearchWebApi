using NewsSearchWebApi.Models;
using System.Collections.Generic;

namespace NewsSearchWebApi.Interfaces
{
    public interface INewsService
    {
        List<News> GetAllNews();
        News GetNewsById(int id);
        void CreateNews(News item);
        void DeleteNews(int id);
    }
}
