using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;

namespace Snow.Ehr.Apps;

public interface IAppService:IApplicationService
{
    Task<List<SettingValue>> GetSettings();

    Task<List<AppDataListDto>> GetDataAsync();
}