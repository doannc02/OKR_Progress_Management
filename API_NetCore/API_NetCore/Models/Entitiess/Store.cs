using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Store
    {
        public long Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string? ProductImage { get; set; }
        public string ProductDescription { get; set; } = null!;
        public int ProductPrice { get; set; }
        public long AdminId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool? IsActived { get; set; }
        public int ProductQuantity { get; set; }
        public bool? IsAlwaysAvaiable { get; set; }
        public int ProductSale { get; set; }
        public int ProductPriority { get; set; }
    }
}
