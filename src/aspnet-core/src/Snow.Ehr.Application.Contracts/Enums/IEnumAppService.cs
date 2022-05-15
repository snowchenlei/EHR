using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Snow.Ehr.Enums;

public interface IEnumAppService : IApplicationService
{
    /// <summary>
    /// 血型
    /// </summary>
    /// <returns></returns>
    Task<IDictionary<int, string>> GetBloodTypeAsync();

    /// <summary>
    /// 星座
    /// </summary>
    /// <returns></returns>
    Task<IDictionary<int, string>> GetConstellationAsync();

    /// <summary>
    /// 性别
    /// </summary>
    /// <returns></returns>
    Task<IDictionary<int, string>> GetGenderAsync();

    /// <summary>
    /// 在职状态
    /// </summary>
    /// <returns></returns>
    Task<IDictionary<int, string>> GetInServiceStatusAsync();

    /// <summary>
    /// 婚姻状态
    /// </summary>
    /// <returns></returns>
    Task<IDictionary<int, string>> GetMaritalStatusAsync();

    /// <summary>
    /// 政治面貌
    /// </summary>
    /// <returns></returns>
    Task<IDictionary<int, string>> GetPoliticalStatusAsync();

    /// <summary>
    /// 属相
    /// </summary>
    /// <returns></returns>
    Task<IDictionary<int, string>> GetZodiacAsync();
}