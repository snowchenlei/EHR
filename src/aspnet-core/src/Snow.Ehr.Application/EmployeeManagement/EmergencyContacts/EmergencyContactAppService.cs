using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Snow.Ehr.EmployeeManagement.EmergencyContacts;
using Snow.Ehr.EmployeeManagement.Employees;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Snow.Ehr.Permissions;

namespace Snow.Ehr.EmployeeManagement.EmergencyContacts
{
    /// <summary>
    /// 紧急联络人管理
    /// </summary>
    [Authorize(EhrPermissions.EmergencyContacts.Default)]
    public class EmergencyContactAppService : EhrAppService, IEmergencyContactAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<EmergencyContact, Guid> _emergencyContactRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="emergencyContactRepository"></param>
        /// <param name="employeeRepository"></param>
        public EmergencyContactAppService(
            [NotNull] IRepository<EmergencyContact, Guid> emergencyContactRepository,
            [NotNull] IRepository<Employee, Guid> employeeRepository)
        {
            _emergencyContactRepository = emergencyContactRepository ?? throw new ArgumentNullException(nameof(emergencyContactRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        public virtual async Task<EmergencyContactDetailDto> GetAsync(Guid employeeId, Guid emergencyContactId)
        {
            await _employeeRepository.GetAsync(employeeId);

            EmergencyContact entity = await _emergencyContactRepository
                .GetAsync(ec => ec.EmployeeId == employeeId && ec.Id == emergencyContactId);

            return ObjectMapper.Map<EmergencyContact, EmergencyContactDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<EmergencyContactListDto>> GetListAsync(Guid employeeId, GetEmergencyContactsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _emergencyContactRepository.GetQueryableAsync();

            queryable = queryable.Where(q => q.EmployeeId == input.EmployeeId);

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
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        public virtual async Task<GetEmergencyContactForEditorOutput> GetEditorAsync(Guid employeeId, Guid emergencyContactId)
        {
            await _employeeRepository.GetAsync(employeeId);
            
            EmergencyContact entity = await _emergencyContactRepository
                .GetAsync(ec => ec.EmployeeId == employeeId && ec.Id == emergencyContactId);

            return ObjectMapper.Map<EmergencyContact, GetEmergencyContactForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(EhrPermissions.EmergencyContacts.Create)]
        public virtual async Task<EmergencyContactListDto> CreateAsync(Guid employeeId, EmergencyContactCreateDto input)
        {
            await _employeeRepository.GetAsync(employeeId);
            
            var entity = ObjectMapper.Map<EmergencyContactCreateDto, EmergencyContact>(input);
            entity.EmployeeId = employeeId;
            entity = await _emergencyContactRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<EmergencyContact, EmergencyContactListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(EhrPermissions.EmergencyContacts.Update)]
        public virtual async Task<EmergencyContactListDto> UpdateAsync(Guid employeeId, Guid emergencyContactId, EmergencyContactUpdateDto input)
        {
            await _employeeRepository.GetAsync(employeeId);

            EmergencyContact entity = await _emergencyContactRepository
                .GetAsync(ec=>ec.EmployeeId == employeeId && ec.Id == emergencyContactId);
            entity = ObjectMapper.Map(input, entity);
            entity = await _emergencyContactRepository.UpdateAsync(entity);
            return ObjectMapper.Map<EmergencyContact, EmergencyContactListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        [Authorize(EhrPermissions.EmergencyContacts.Delete)]
        public virtual async Task DeleteAsync(Guid employeeId, Guid emergencyContactId)
        {
            await _employeeRepository.GetAsync(employeeId);

            await _emergencyContactRepository
                .DeleteAsync(ec => ec.EmployeeId == employeeId && ec.Id == emergencyContactId);
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
