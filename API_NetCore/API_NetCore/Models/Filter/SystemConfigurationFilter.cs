namespace OKEA.Library.Models.Filter
{
    public class SystemConfigurationFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? ConfigTypeId { get; set; }
        public string ConfigType { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string Description { get; set; }
    }
}
