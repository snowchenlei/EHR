using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos;
using Snow.Hcm.Permissions;

namespace Snow.Hcm.EmployeeManagement.EmergencyContacts
{
    /// <summary>
    /// 紧急联络人管理
    /// </summary>
    [Authorize(HcmPermissions.EmergencyContacts.Default)]
    public class EmergencyContactAppService : HcmAppService, IEmergencyContactAppService
    {
        private readonly IRepository<EmergencyContact, Guid> _emergencyContactRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="emergencyContactRepository"></param>
        public EmergencyContactAppService(
            IRepository<EmergencyContact, Guid> emergencyContactRepository)
        {
            _emergencyContactRepository = emergencyContactRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<EmergencyContactDetailDto> GetAsync(Guid id)
        {
            EmergencyContact entity = await _emergencyContactRepository.GetAsync(id);

            return ObjectMapper.Map<EmergencyContact, EmergencyContactDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<EmergencyContactListDto>> GetListAsync(GetEmergencyContactsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _emergencyContactRepository.GetQueryableAsync();

             long totalCount = await AsyncExecuter.CountAsync(queryable);
            
            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? "Id DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<EmergencyContact>, List<EmergencyContactListDto>>(entities);

            return new PagedResultDto<EmergencyContactListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetEmergencyContactForEditorOutput> GetEditorAsync(Guid id)
        {
            EmergencyContact entity = await _emergencyContactRepository.GetAsync(id);

            return ObjectMapper.Map<EmergencyContact, GetEmergencyContactForEditorOutput>(entity);
        }
    
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.EmergencyContacts.Create)]
        public virtual async Task<EmergencyContactListDto> CreateAsync(EmergencyContactCreateDto input)
        {
            var entity = ObjectMapper.Map<EmergencyContactCreateDto, EmergencyContact>(input);
            entity = await _emergencyContactRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<EmergencyContact, EmergencyContactListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.EmergencyContacts.Update)]
        public virtual async Task<EmergencyContactListDto> UpdateAsync(Guid id, EmergencyContactUpdateDto input)
        {
            EmergencyContact entity = await _emergencyContactRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _emergencyContactRepository.UpdateAsync(entity);
            return ObjectMapper.Map<EmergencyContact, EmergencyContactListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.EmergencyContacts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _emergencyContactRepository.DeleteAsync(s => s.Id == id);
        }

        

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(EmergencyContactSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
