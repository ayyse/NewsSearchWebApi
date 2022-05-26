using NewsSearchWebApi.Interfaces;
using NewsSearchWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NewsSearchWebApi.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly AppDbContext _context;
        public KeywordService(AppDbContext context)
        {
            _context = context;
        }
        public void CreateKeyword(Keyword item)
        {
            var x = GetAllKeywords().Where(x => x.Word == item.Word).ToList();

            if (x.Count == 0)
            {
                _context.Keywords.Add(item);
                _context.SaveChanges();
            }
        }

        public void DeleteKeyword(int id)
        {
            var deletedKeyword = _context.Keywords.Where(x => x.Id == id).FirstOrDefault();
            _context.Keywords.Remove(deletedKeyword);
            _context.SaveChanges();
        }

        public List<Keyword> GetAllKeywords()
        {
            var list = _context.Keywords.ToList();
            return list;
        }

        public Keyword GetKeywordById(int id)
        {
            var getItem = _context.Keywords.Where(x => x.Id == id).FirstOrDefault();
            return getItem;
        }

        public void UpdateKeyword(int id)
        {
            var updatedKeyword = _context.Keywords.Where(x => x.Id == id).FirstOrDefault();
            _context.Keywords.Update(updatedKeyword);
            _context.SaveChanges();
        }
    }
}
