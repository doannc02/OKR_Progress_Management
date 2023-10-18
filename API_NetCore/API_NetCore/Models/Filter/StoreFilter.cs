namespace OKEA.Library.Models.Filter
{
    public class StoreFilter : FilterBase
    {
        public long? Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
        public long? AdminId { get; set; }
        public bool? IsAlwaysAvaiable { get; set; }
    }
}
