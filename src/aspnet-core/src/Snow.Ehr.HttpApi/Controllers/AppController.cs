using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Snow.Ehr.Apps;

namespace Snow.Ehr.Controllers;

/// <summary>
/// App
/// </summary>
[Route("api/app")]
public class AppController : EhrController
{
    private readonly IConfiguration _configuration;
    private readonly IAppService _appService;

    public AppController(IConfiguration configuration, IAppService appService)
    {
        _configuration = configuration;
        _appService = appService;
    }

    [HttpGet("setting")]
    public async Task<IActionResult> GetSettings()
    {
        return Ok(await _appService.GetSettings());
    }

    /// <summary>
    /// 基础数据
    /// </summary>
    /// <returns></returns>
    [HttpGet("data")]
    public async Task<IActionResult> GetDataAsync()
    {
        List<AppDataListDto> resultMenus = await _appService.GetDataAsync();
        return Ok(new
        {
            App = new
            {
                Name = _configuration["App:ApplicationName"],
                Description = _configuration["App:ApplicationDescription"]
            },
            User = new
            {
                Name = CurrentUser.UserName,
                Email = CurrentUser.Email,
                Avatar = ""
            },
            Menu = resultMenus
        });
    }
}