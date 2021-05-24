using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

using Snow.Hcm.EmployeeManagement.EducationExperiences;
using Snow.Hcm.EmployeeManagement.EducationExperiences.Dtos;
using System;

namespace Snow.Hcm.Controllers.Employees
{
    /// <summary>
    /// 教育经历
    /// </summary>
    [Route("api/employee/{employeeId}/education-experience")]
    public class EducationExperienceController : HcmController, IEducationExperienceAppService
    {
        private readonly IEducationExperienceAppService _educationExperienceAppService;

        public EducationExperienceController(IEducationExperienceAppService educationExperienceAppService)
        {
            _educationExperienceAppService = educationExperienceAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        [HttpGet("{workExperienceId}")]
        public virtual async Task<EducationExperienceDetailDto> GetAsync(Guid employeeId, Guid workExperienceId)
        {
            return await _educationExperienceAppService.GetAsync(employeeId, workExperienceId);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<EducationExperienceListDto>> GetListAsync(Guid employeeId, GetEducationExperiencesInput input)
        {
            return await _educationExperienceAppService.GetListAsync(employeeId, input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        [HttpGet("{workExperienceId}/editor")]
        public virtual async Task<GetEducationExperienceForEditorOutput> GetEditorAsync(Guid employeeId, Guid workExperienceId)
        {
            return await _educationExperienceAppService.GetEditorAsync(employeeId, workExperienceId);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<EducationExperienceListDto> CreateAsync(Guid employeeId, EducationExperienceCreateDto input)
        {
            return await _educationExperienceAppService.CreateAsync(employeeId, input);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{workExperienceId}")]
        public virtual async Task<EducationExperienceListDto> UpdateAsync(Guid employeeId, Guid workExperienceId, EducationExperienceUpdateDto input)
        {
            return await _educationExperienceAppService.UpdateAsync(employeeId, workExperienceId, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        [HttpDelete("{workExperienceId}")]
        public virtual async Task DeleteAsync(Guid employeeId, Guid workExperienceId)
        {
            await _educationExperienceAppService.DeleteAsync(employeeId, workExperienceId);
        }
    }
}
