using NewsSearchWebApi.Models;
using System.Collections.Generic;

namespace NewsSearchWebApi.Interfaces
{
    public interface IKeywordService
    {
        List<Keyword> GetAllKeywords();
        void CreateKeyword(Keyword item);
        void UpdateKeyword(int id);
        void DeleteKeyword(int id);
        Keyword GetKeywordById(int id);
    }
}
