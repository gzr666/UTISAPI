using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UtisAPI.Models;

namespace UtisAPI.ModelHelpers
{
    public class PagedResult
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<User> Users { get; set; }


    }
}