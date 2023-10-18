using OKEA.Library.Models.Enums;

namespace API_NetCore.Models.DataTranferObject
{
    public class DTO_Obj
    {
        public long? Id { get; set; }
        public long? OkrId { get; set; }
        public long? UserId { get; set; }
        public string OkrName { get; set; }
        public string ObjectiveName { get; set; }
        public int? ObjectivePercent { get; set; }
        public ObjectiveType? ObjectiveType { get; set; }
        public Status? Status { get; set; }
        public List<DTO_KR> KeyResults { get; set; }
    }
}
