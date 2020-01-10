using System.Threading.Tasks;
using ABP.TPLMS.Configuration.Dto;

namespace ABP.TPLMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
