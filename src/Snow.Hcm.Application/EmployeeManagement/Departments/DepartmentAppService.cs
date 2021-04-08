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
using Snow.Hcm.EmployeeManagement.Departments.Dtos;
using Snow.Hcm.Permissions;

namespace Snow.Hcm.EmployeeManagement.Departments
{
    /// <summary>
    /// 部门管理
    /// </summary>
    [Authorize(HcmPermissions.Departments.Default)]
    public class DepartmentAppService : HcmAppService, IDepartmentAppService
    {
        private readonly IRepository<Department, System.Guid> _departmentRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="departmentRepository"></param>
        public DepartmentAppService(
            IRepository<Department, System.Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<DepartmentDetailDto> GetAsync(System.Guid id)
        {
            Department entity = await _departmentRepository.GetAsync(id);

            return ObjectMapper.Map<Department, DepartmentDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<DepartmentListDto>> GetListAsync(GetDepartmentsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _departmentRepository.GetQueryableAsync();

             long totalCount = await AsyncExecuter.CountAsync(queryable);
            
            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? "Id DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Department>, List<DepartmentListDto>>(entities);

            return new PagedResultDto<DepartmentListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetDepartmentForEditorOutput> GetEditorAsync(System.Guid id)
        {
            Department entity = await _departmentRepository.GetAsync(id);

            return ObjectMapper.Map<Department, GetDepartmentForEditorOutput>(entity);
        }
    
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Departments.Create)]
        public virtual async Task<DepartmentListDto> CreateAsync(DepartmentCreateDto input)
        {
            var entity = ObjectMapper.Map<DepartmentCreateDto, Department>(input);
            entity = await _departmentRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Department, DepartmentListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Departments.Update)]
        public virtual async Task<DepartmentListDto> UpdateAsync(System.Guid id, DepartmentUpdateDto input)
        {
            Department entity = await _departmentRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _departmentRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Department, DepartmentListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Departments.Delete)]
        public virtual async Task DeleteAsync(System.Guid id)
        {
            await _departmentRepository.DeleteAsync(s => s.Id == id);
        }

        

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(DepartmentSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
