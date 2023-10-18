using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class SendMailCheckIn
    {
        public long quarterId { get; set; }
        public string quarterName { get; set; }
        public int? star { get; set; }
        public List<OkrSendMail> okrSendMail { get; set; }
        public List<ObjectiveSendMail> ObjectiveSendMail { get; set; }
        public List<KeyResultSendMail> keyResultSendMail { get; set; }
        public List<KeyResultActionSendMail> keyResultActionSendMail { get; set; }
    }
    public class OkrSendMail
    {
        public long? OkrId { get; set; }
        public string OkrName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
    public class ObjectiveSendMail
    {
        public long? ObjectiveId { get; set; }
        public string ObjectiveName { get; set; }
        public int? ObjectivePrecent { get; set; }
        public int? ConfidenceLevel { get; set; }
        public long OkrId { get; set; }
    }
    public class KeyResultSendMail
    {
        public long? KeyResultId { get; set; }
        public string KeyResultName { get; set; }
        public int? KeyResultPrecent { get; set; }
        public int? ConfidenceLevel { get; set; }
        public long? ObjectiveId { get; set; }
        public string QuarterId { get; set; }
    }
    public class KeyResultActionSendMail
    {
        public long? KeyResultActionId { get; set; }
        public string KeyResultActionName { get; set; }
        public long? KeyResultId { get; set; }
        public string QuarterId { get; set; }
    }
}
