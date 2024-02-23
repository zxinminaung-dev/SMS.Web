using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace WebApplication1.Common
{
    public class QueryOption<TEntity> where TEntity : IEntity
    {
        public QueryOption() { }
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
        public string SortColumnName { get; set; } = "Id";
        public string SortOrder { get; set; } = "DESC";
        public Expression<Func<TEntity, bool>> FilterBy { get; set; }
        public Func<TEntity, object> SortBy { get; set; }
        
    }
}
