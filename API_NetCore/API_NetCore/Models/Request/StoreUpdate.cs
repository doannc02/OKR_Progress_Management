using System;

namespace OKEA.Library.Models.Request
{
    public class StoreUpdate
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductQuantity { get; set; }
        public int? ProductPrice { get; set; }
        public long? AdminId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsAlwaysAvaiable { get; set; }
        public bool? IsActived { get; set; }
    }
}
