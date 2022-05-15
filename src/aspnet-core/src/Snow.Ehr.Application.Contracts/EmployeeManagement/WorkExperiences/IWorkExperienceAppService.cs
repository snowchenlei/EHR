using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Snow.Ehr.EmployeeManagement.WorkExperiences;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Snow.Ehr.EmployeeManagement.WorkExperiences
{
    /// <summary>
    /// 工作经历管理
    /// </summary>
    public interface IWorkExperienceAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        Task<WorkExperienceDetailDto> GetAsync(Guid employeeId, Guid workExperienceId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<WorkExperienceListDto>> GetListAsync(Guid employeeId, GetWorkExperiencesInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        Task<GetWorkExperienceForEditorOutput> GetEditorAsync(Guid employeeId, Guid workExperienceId);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WorkExperienceListDto> CreateAsync(Guid employeeId, [NotNull] WorkExperienceCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WorkExperienceListDto> UpdateAsync(Guid employeeId, Guid workExperienceId, [NotNull] WorkExperienceUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="workExperienceId">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid employeeId, Guid workExperienceId);
    }
}