using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ABP.TPLMS.Configuration.Dto;

namespace ABP.TPLMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TPLMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
