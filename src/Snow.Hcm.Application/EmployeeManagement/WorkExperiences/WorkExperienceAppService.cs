using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Snow.Hcm.EmployeeManagement.Employees;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos;
using Snow.Hcm.Permissions;

namespace Snow.Hcm.EmployeeManagement.WorkExperiences
{
    /// <summary>
    /// 工作经历管理
    /// </summary>
    [Authorize(HcmPermissions.WorkExperiences.Default)]
    public class WorkExperienceAppService : HcmAppService, IWorkExperienceAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<WorkExperience, Guid> _workExperienceRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="employeeRepository"></param>
        /// <param name="workExperienceRepository"></param>
        public WorkExperienceAppService(
            [NotNull] IRepository<Employee, Guid> employeeRepository,
            [NotNull] IRepository<WorkExperience, Guid> workExperienceRepository)
        {
            _workExperienceRepository = workExperienceRepository ?? throw new ArgumentNullException(nameof(workExperienceRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        public virtual async Task<WorkExperienceDetailDto> GetAsync(Guid employeeId, Guid workExperienceId)
        {
            await _employeeRepository.GetAsync(employeeId);
            WorkExperience entity = await _workExperienceRepository
                .GetAsync(w=>w.EmployeeId == employeeId && w.Id == workExperienceId);

            return ObjectMapper.Map<WorkExperience, WorkExperienceDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<WorkExperienceListDto>> GetListAsync(Guid employeeId, GetWorkExperiencesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _workExperienceRepository.GetQueryableAsync();

            queryable = queryable.Where(w => w.EmployeeId == employeeId);
            
             long totalCount = await AsyncExecuter.CountAsync(queryable);
            
            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? "Id DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<WorkExperience>, List<WorkExperienceListDto>>(entities);

            return new PagedResultDto<WorkExperienceListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        public virtual async Task<GetWorkExperienceForEditorOutput> GetEditorAsync(Guid employeeId, Guid workExperienceId)
        {
            await _employeeRepository.GetAsync(employeeId);
            WorkExperience entity = await _workExperienceRepository
                .GetAsync(w=>w.EmployeeId == employeeId && w.Id == workExperienceId);

            return ObjectMapper.Map<WorkExperience, GetWorkExperienceForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.WorkExperiences.Create)]
        public virtual async Task<WorkExperienceListDto> CreateAsync(Guid employeeId, WorkExperienceCreateDto input)
        {
            await _employeeRepository.GetAsync(employeeId);

            var entity = ObjectMapper.Map<WorkExperienceCreateDto, WorkExperience>(input);
            entity.EmployeeId = employeeId;
            entity = await _workExperienceRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<WorkExperience, WorkExperienceListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.WorkExperiences.Update)]
        public virtual async Task<WorkExperienceListDto> UpdateAsync(Guid employeeId, Guid workExperienceId, WorkExperienceUpdateDto input)
        {
            await _employeeRepository.GetAsync(employeeId);

            WorkExperience entity = await _workExperienceRepository
                .GetAsync(w=>w.EmployeeId == employeeId && w.Id == workExperienceId);
            entity = ObjectMapper.Map(input, entity);
            entity = await _workExperienceRepository.UpdateAsync(entity);
            return ObjectMapper.Map<WorkExperience, WorkExperienceListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.WorkExperiences.Delete)]
        public virtual async Task DeleteAsync(Guid employeeId, Guid workExperienceId)
        {
            await _employeeRepository.GetAsync(employeeId);

            await _workExperienceRepository
                .DeleteAsync(s => s.EmployeeId == employeeId && s.Id == workExperienceId);
        }

        

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(WorkExperienceSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
