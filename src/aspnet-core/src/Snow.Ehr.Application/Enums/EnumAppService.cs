using System.Collections.Generic;
using System.Threading.Tasks;
using Snow.Ehr.EmployeeManagement.Employees;
using Snow.Ehr.Util;
using Volo.Abp.Caching;

namespace Snow.Ehr.Enums;

public class EnumAppService : EhrAppService, IEnumAppService
{
    private readonly IDistributedCache<Dictionary<int, string>> _distributedCache;

    public EnumAppService(IDistributedCache<Dictionary<int, string>> distributedCache)
    {
        _distributedCache = distributedCache;
    }
    
    public async Task<IDictionary<int, string>> GetBloodTypeAsync()
    {
        return await _distributedCache.GetOrAddAsync("enum_blood_type",
            async () => await Task.FromResult(typeof(BloodType).GetValueAndDescription()));
    }
    public async Task<IDictionary<int, string>> GetConstellationAsync()
    {
        return await _distributedCache.GetOrAddAsync("enum_constellation",
            async () => await Task.FromResult(typeof(Constellation).GetValueAndDescription()));
    }
    public async Task<IDictionary<int, string>> GetGenderAsync()
    {
        return await _distributedCache.GetOrAddAsync("enum_gender",
            async () => await Task.FromResult(typeof(Gender).GetValueAndDescription()));
    }
    
    public async Task<IDictionary<int, string>> GetInServiceStatusAsync()
    {
        return await _distributedCache.GetOrAddAsync("enum_in_service_status",
            async () => await Task.FromResult(typeof(InServiceStatus).GetValueAndDescription()));
    }
    public async Task<IDictionary<int, string>> GetMaritalStatusAsync()
    {
        return await _distributedCache.GetOrAddAsync("enum_marital_status",
            async () => await Task.FromResult(typeof(MaritalStatus).GetValueAndDescription()));
    }
    public async Task<IDictionary<int, string>> GetPoliticalStatusAsync()
    {
        return await _distributedCache.GetOrAddAsync("enum_political_status",
            async () => await Task.FromResult(typeof(PoliticalStatus).GetValueAndDescription()));
    }
    public async Task<IDictionary<int, string>> GetZodiacAsync()
    {
        return await _distributedCache.GetOrAddAsync("enum_zodiac",
            async () => await Task.FromResult(typeof(Zodiac).GetValueAndDescription()));
    }
}