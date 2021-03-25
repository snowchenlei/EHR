using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Lzez.Tendering.Admin.Enums
{
    /// <summary>
    /// 枚举服务
    /// </summary>
    public interface IEnumAppService:IApplicationService
    {
        /// <summary>
        /// 审核状态
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, int>> GetGenderAsync();
    }
}