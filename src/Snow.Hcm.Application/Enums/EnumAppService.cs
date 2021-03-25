using System.Collections.Generic;
using System.Threading.Tasks;
using Masuit.Tools.Systems;
using Snow.Hcm;
using Snow.Hcm.EmployeeManagement.Employees;
using Volo.Abp.Caching;

namespace Lzez.Tendering.Admin.Enums
{
    /// <summary>
    /// 枚举服务
    /// </summary>
    public class EnumAppService : HcmAppService, IEnumAppService
    {
        private readonly IDistributedCache<Dictionary<string, int>> _distributedCache;

        public EnumAppService(IDistributedCache<Dictionary<string, int>> distributedCache)
        {
            _distributedCache = distributedCache;
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, int>> GetGenderAsync()
        {
            return await _distributedCache.GetOrAddAsync("enum_gender",
                async () => await Task.FromResult(typeof(Gender).GetDescriptionAndValue()));
        }
    }
}