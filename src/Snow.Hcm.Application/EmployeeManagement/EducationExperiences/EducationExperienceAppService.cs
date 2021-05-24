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
using Snow.Hcm.EmployeeManagement.EducationExperiences.Dtos;
using Snow.Hcm.Permissions;

namespace Snow.Hcm.EmployeeManagement.EducationExperiences
{
    /// <summary>
    /// 教育经历管理
    /// </summary>
    [Authorize(HcmPermissions.EducationExperiences.Default)]
    public class EducationExperienceAppService : HcmAppService, IEducationExperienceAppService
    {
        private readonly IRepository<EducationExperience, System.Guid> _educationExperienceRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="educationExperienceRepository"></param>
        public EducationExperienceAppService(
            IRepository<EducationExperience, Guid> educationExperienceRepository)
        {
            _educationExperienceRepository = educationExperienceRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <returns></returns>
        public virtual async Task<EducationExperienceDetailDto> GetAsync(Guid employeeId, Guid educationExperienceId)
        {
            EducationExperience entity = await _educationExperienceRepository.GetAsync(educationExperienceId);

            return ObjectMapper.Map<EducationExperience, EducationExperienceDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<EducationExperienceListDto>> GetListAsync(Guid employeeId, GetEducationExperiencesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _educationExperienceRepository.GetQueryableAsync();

             long totalCount = await AsyncExecuter.CountAsync(queryable);
            
            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? "Id DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<EducationExperience>, List<EducationExperienceListDto>>(entities);

            return new PagedResultDto<EducationExperienceListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <returns></returns>
        public virtual async Task<GetEducationExperienceForEditorOutput> GetEditorAsync(Guid employeeId, Guid educationExperienceId)
        {
            EducationExperience entity = await _educationExperienceRepository.GetAsync(educationExperienceId);

            return ObjectMapper.Map<EducationExperience, GetEducationExperienceForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.EducationExperiences.Create)]
        public virtual async Task<EducationExperienceListDto> CreateAsync(Guid employeeId, EducationExperienceCreateDto input)
        {
            var entity = ObjectMapper.Map<EducationExperienceCreateDto, EducationExperience>(input);
            entity = await _educationExperienceRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<EducationExperience, EducationExperienceListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.EducationExperiences.Update)]
        public virtual async Task<EducationExperienceListDto> UpdateAsync(Guid employeeId, Guid educationExperienceId, EducationExperienceUpdateDto input)
        {
            EducationExperience entity = await _educationExperienceRepository.GetAsync(educationExperienceId);
            entity = ObjectMapper.Map(input, entity);
            entity = await _educationExperienceRepository.UpdateAsync(entity);
            return ObjectMapper.Map<EducationExperience, EducationExperienceListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.EducationExperiences.Delete)]
        public virtual async Task DeleteAsync(Guid employeeId, Guid educationExperienceId)
        {
            await _educationExperienceRepository.DeleteAsync(s => s.Id == educationExperienceId);
        }
        
        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(EducationExperienceSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
