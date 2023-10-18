namespace OKEA.Library.Models.Filter
{
    public class CFRSuggestCommentFilter : FilterBase
    {
        public long? Id { get; set; }
        public string Comment { get; set; }
        public int? Star { get; set; }
    }
}
