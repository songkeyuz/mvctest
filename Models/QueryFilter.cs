using System;
using System.Collections.Generic;
using System.Linq;

namespace mvctest.Models
{
    public class QueryFilter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortFields { get; set; }
        public int draw { get; set; }

    }

    public class QueryResult<T> : QueryFilter
    {
        public QueryResult()
        {
            data = new List<T>();
        }

        public int recordsTotal { get; set; }
        public int recordsFiltered { get; }
        public List<T> data { get; set; }
        public string Summary { get; set; }
    }
}