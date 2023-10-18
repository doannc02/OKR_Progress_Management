using DapperExtensions.Predicate;
using System.Collections.Generic;

namespace OKEA.Library.Models.Filter
{
    /// <summary>
    /// FilterBase
    /// </summary>
    public class FilterBase
    {
        /// <summary>
        /// Limit records
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Page on paging
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// IsActived
        /// </summary>
        public bool? IsActived { get; set; }
        /// <summary>
        /// Sorted
        /// </summary>
        public List<Sort> OrderBy { get; set; }
    }
}
