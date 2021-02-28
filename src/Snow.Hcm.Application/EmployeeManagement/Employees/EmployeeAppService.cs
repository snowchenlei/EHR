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
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Permissions;

namespace Snow.Hcm.EmployeeManagement.Employees
{
    /// <summary>
    /// 员工管理
    /// </summary>
    [Authorize(HcmPermissions.Employees.Default)]
    public class EmployeeAppService : HcmAppService, IEmployeeAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeAppService(
            IRepository<Employee, Guid> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<EmployeeDetailDto> GetAsync(System.Guid id)
        {
            Employee entity = await _employeeRepository.GetAsync(id);

            return ObjectMapper.Map<Employee, EmployeeDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<EmployeeListDto>> GetListAsync(GetEmployeesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _employeeRepository.GetQueryableAsync();

             long totalCount = await AsyncExecuter.CountAsync(queryable);
            
            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? "Id DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Employee>, List<EmployeeListDto>>(entities);

            return new PagedResultDto<EmployeeListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetEmployeeForEditorOutput> GetEditorAsync(System.Guid id)
        {
            Employee entity = await _employeeRepository.GetAsync(id);

            return ObjectMapper.Map<Employee, GetEmployeeForEditorOutput>(entity);
        }
    
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Employees.Create)]
        public virtual async Task<EmployeeListDto> CreateAsync(EmployeeCreateDto input)
        {
            var entity = ObjectMapper.Map<EmployeeCreateDto, Employee>(input);
            entity = await _employeeRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Employee, EmployeeListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Employees.Update)]
        public virtual async Task<EmployeeListDto> UpdateAsync(System.Guid id, EmployeeUpdateDto input)
        {
            Employee entity = await _employeeRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _employeeRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Employee, EmployeeListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Employees.Delete)]
        public virtual async Task DeleteAsync(System.Guid id)
        {
            await _employeeRepository.DeleteAsync(s => s.Id == id);
        }
        
        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(EmployeeSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
