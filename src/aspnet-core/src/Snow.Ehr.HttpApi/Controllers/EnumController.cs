using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snow.Ehr.Enums;

namespace Snow.Ehr.Controllers;

/// <summary>
/// 枚举
/// </summary>
[Route("api/enum")]
public class EnumController : EhrController, IEnumAppService
{
    private readonly IEnumAppService _enumAppService;

    public EnumController(IEnumAppService enumAppService)
    {
        _enumAppService = enumAppService;
    }

    /// <summary>
    /// 血型
    /// </summary>
    /// <returns></returns>
    [HttpGet("blood-type")]
    public virtual async Task<IDictionary<int, string>> GetBloodTypeAsync()
    {
        return await _enumAppService.GetBloodTypeAsync();
    }

    /// <summary>
    /// 星座
    /// </summary>
    /// <returns></returns>
    [HttpGet("constellation")]
    public virtual async Task<IDictionary<int, string>> GetConstellationAsync()
    {
        return await _enumAppService.GetConstellationAsync();
    }

    /// <summary>
    /// 性别
    /// </summary>
    /// <returns></returns>
    [HttpGet("gender")]
    public virtual async Task<IDictionary<int, string>> GetGenderAsync()
    {
        return await _enumAppService.GetGenderAsync();
    }

    /// <summary>
    /// 在职状态
    /// </summary>
    /// <returns></returns>
    [HttpGet("in-service-status")]
    public virtual async Task<IDictionary<int, string>> GetInServiceStatusAsync()
    {
        return await _enumAppService.GetInServiceStatusAsync();
    }

    /// <summary>
    /// 婚姻状态
    /// </summary>
    /// <returns></returns>
    [HttpGet("marital-status")]
    public virtual async Task<IDictionary<int, string>> GetMaritalStatusAsync()
    {
        return await _enumAppService.GetMaritalStatusAsync();
    }

    /// <summary>
    /// 政治面貌
    /// </summary>
    /// <returns></returns>
    [HttpGet("political-status")]
    public virtual async Task<IDictionary<int, string>> GetPoliticalStatusAsync()
    {
        return await _enumAppService.GetPoliticalStatusAsync();
    }

    /// <summary>
    /// 属相
    /// </summary>
    /// <returns></returns>
    [HttpGet("zodiac")]
    public virtual async Task<IDictionary<int, string>> GetZodiacAsync()
    {
        return await _enumAppService.GetZodiacAsync();
    }
    
}