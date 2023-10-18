using System;
using System.Collections.Generic;
using System.Text;

namespace OKEA.Library.Models.Filter
{
    public class StarFundFilter : FilterBase
    {
        public long? Id { get; set; }
        /// <summary>
        /// Năm của Quỹ Sao
        /// </summary>
        public int? YearFund { get; set; }
        /// <summary>
        /// Tổng số lượng sao của năm
        /// </summary>
        public long? TotalStar { get; set; }
        /// <summary>
        /// Số lượng sao đã sử dụng
        /// </summary>
        public long? CurrentUseStar { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreateDTime { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public long? CreateBy { get; set; }
        /// <summary>
        /// Ngày update cuối cùng
        /// </summary>
        public DateTime? UpdateLUDTime { get; set; }
        /// <summary>
        /// Người update cuối cùng
        /// </summary>
        public long? UpdateLUBy { get; set; }
    }
}
