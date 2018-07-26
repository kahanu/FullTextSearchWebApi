using FTS.Library.Search.Models;
using System.Collections.Generic;

namespace FTS.Library.Search.RnR
{
    public class SearchRequest : BaseRequest
    {
        public List<SearchCriteria> SearchCriteria { get; set; } = new List<SearchCriteria>();
    }
}
