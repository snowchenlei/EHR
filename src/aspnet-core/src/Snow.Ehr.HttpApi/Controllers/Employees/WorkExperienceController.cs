using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snow.Ehr.EmployeeManagement.WorkExperiences;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.Controllers.Employees
{
    /// <summary>
    /// 工作经历
    /// </summary>
    [Route("api/employee/{employeeId}/work-experience")]
    public class WorkExperienceController : EhrController, IWorkExperienceAppService
    {
        private readonly IWorkExperienceAppService _workExperienceAppService;

        public WorkExperienceController(IWorkExperienceAppService workExperienceAppService)
        {
            _workExperienceAppService = workExperienceAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{workExperienceId}")]
        public virtual async Task<WorkExperienceDetailDto> GetAsync(Guid employeeId, Guid workExperienceId)
        {
            return await _workExperienceAppService.GetAsync(employeeId, workExperienceId);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<WorkExperienceListDto>> GetListAsync(Guid employeeId, GetWorkExperiencesInput input)
        {
            return await _workExperienceAppService.GetListAsync(employeeId, input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{workExperienceId}/editor")]
        public virtual async Task<GetWorkExperienceForEditorOutput> GetEditorAsync(Guid employeeId, Guid workExperienceId)
        {
            return await _workExperienceAppService.GetEditorAsync(employeeId, workExperienceId);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<WorkExperienceListDto> CreateAsync(Guid employeeId, WorkExperienceCreateDto input)
        {
            return await _workExperienceAppService.CreateAsync(employeeId, input);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{workExperienceId}")]
        public virtual async Task<WorkExperienceListDto> UpdateAsync(Guid employeeId, Guid workExperienceId, WorkExperienceUpdateDto input)
        {
            return await _workExperienceAppService.UpdateAsync(employeeId, workExperienceId, input);
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
            await _workExperienceAppService.DeleteAsync(employeeId, workExperienceId);
        }
    }
}
