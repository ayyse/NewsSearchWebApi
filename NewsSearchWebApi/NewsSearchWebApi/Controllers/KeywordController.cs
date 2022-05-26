using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsSearchWebApi.Interfaces;
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
        private readonly IKeywordService _keywordService;
        public KeywordController(AppDbContext context, IKeywordService keywordService)
        {
            _context = context;
            _keywordService = keywordService;
        }

        [HttpGet]
        public List<Keyword> GetAllKeywords()
        {
            var keywordList = _keywordService.GetAllKeywords();
            return keywordList;
        }

        [HttpPost]
        public void CreateKeyword(Keyword item)
        {
            _keywordService.CreateKeyword(item);
        }

        [HttpDelete("{id}")]
        public void DeleteKeyword(int id)
        {
            _keywordService.DeleteKeyword(id);
        }

        [HttpPut("{id}")]
        public void UpdateKeyword(int id)
        {
            _keywordService.UpdateKeyword(id);
        }

        [HttpGet("{id}")]
        public Keyword GetKeywordById(int id)
        {
            var keyword  = _keywordService.GetKeywordById(id);
            return keyword;
        }
    }
}
