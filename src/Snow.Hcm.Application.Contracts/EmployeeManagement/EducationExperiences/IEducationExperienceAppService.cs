using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Snow.Hcm.EmployeeManagement.EducationExperiences.Dtos;
using System;

namespace Snow.Hcm.EmployeeManagement.EducationExperiences
{
    /// <summary>
    /// 教育经历管理
    /// </summary>
    public interface IEducationExperienceAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <returns></returns>
        Task<EducationExperienceDetailDto> GetAsync(Guid employeeId, Guid educationExperienceId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<EducationExperienceListDto>> GetListAsync(Guid employeeId, GetEducationExperiencesInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <returns></returns>
        Task<GetEducationExperienceForEditorOutput> GetEditorAsync(Guid employeeId, Guid educationExperienceId);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EducationExperienceListDto> CreateAsync(Guid employeeId, EducationExperienceCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EducationExperienceListDto> UpdateAsync(Guid employeeId, Guid educationExperienceId, EducationExperienceUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="educationExperienceId">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid employeeId, Guid educationExperienceId);
    }
}