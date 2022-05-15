using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Snow.MenuManagement.Menus;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Snow.Ehr.Apps;

public class AppService:EhrAppService, IAppService
{
    private readonly IMenuRepository _menuRepository;
    private readonly ISettingManager _settingManager;

    public AppService([NotNull] IMenuRepository menuRepository, [NotNull] ISettingManager settingManager)
    {
        _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));
        _settingManager = settingManager ?? throw new ArgumentNullException(nameof(settingManager));
    }

    public async Task<List<SettingValue>> GetSettings()
    {
        return await _settingManager.GetAllGlobalAsync();
    }

    public async Task<List<AppDataListDto>> GetDataAsync()
    {
        var menus = (await _menuRepository.GetListAsync())
            .OrderByDescending(m => m.Sort)
            .ToList();
        List<AppDataListDto> resultMenus = new List<AppDataListDto>();
        foreach (var menuDto in menus.Where(m => !m.ParentId.HasValue))
        {
            var children = await GetChildAsync(menuDto.Id, menus);
            if (children.Count == 0 && menus.Any(m => m.ParentId == menuDto.Id))
            {
                // TODO:有子菜单且子菜单均无权限，则不显示父菜单
                continue;
            }
            resultMenus.Add(new AppDataListDto
            {
                Group = menuDto.Group,
                HideInBreadcrumb = menuDto.HideInBreadcrumb,
                Text = menuDto.Name,
                Icon = menuDto.Icon,
                Link = menuDto.Route,
                Children = children
            });
        }
        return resultMenus;
    }

    private async Task<List<AppDataListDto>> GetChildAsync(int parentId, List<Menu> menus)
    {
        List<AppDataListDto> resultMenus = new List<AppDataListDto>();
        foreach (var menuDto in menus.Where(m => m.ParentId == parentId))
        {
            var children = await GetChildAsync(menuDto.Id, menus);
            if (children.Count == 0 && menus.Any(m => m.ParentId == menuDto.Id))
            {
                // TODO:有子菜单且子菜单均无权限，则不显示父菜单
                continue;
            }
            if (menuDto.Permission.IsNullOrWhiteSpace())
            {                    
                resultMenus.Add(new AppDataListDto
                {
                    Group = menuDto.Group,
                    HideInBreadcrumb = menuDto.HideInBreadcrumb,
                    Text = menuDto.Name,
                    Icon = menuDto.Icon,
                    Link = menuDto.Route,
                    Children = children
                });
            }
            else
            {
                if (await AuthorizationService.IsGrantedAsync(menuDto.Permission))
                {
                    resultMenus.Add(new AppDataListDto
                    {
                        Group = menuDto.Group,
                        HideInBreadcrumb = menuDto.HideInBreadcrumb,
                        Text = menuDto.Name,
                        Icon = menuDto.Icon,
                        Link = menuDto.Route,
                        Children = children
                    });
                }
            }
        }

        return resultMenus;
    }
}