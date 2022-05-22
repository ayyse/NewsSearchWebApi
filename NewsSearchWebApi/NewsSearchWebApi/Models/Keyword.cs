using System.Collections.Generic;

namespace NewsSearchWebApi.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Word { get; set; }

        public virtual List<News> News { get; set; }
    }
}
