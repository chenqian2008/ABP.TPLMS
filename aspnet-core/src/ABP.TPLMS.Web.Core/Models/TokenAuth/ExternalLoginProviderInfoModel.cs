using Abp.AutoMapper;
using ABP.TPLMS.Authentication.External;

namespace ABP.TPLMS.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
