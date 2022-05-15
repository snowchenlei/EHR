using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System;
using Snow.Ehr.EmployeeManagement.EmergencyContacts;

namespace Snow.Ehr.EmployeeManagement.EmergencyContacts
{
    /// <summary>
    /// 紧急联络人管理
    /// </summary>
    public interface IEmergencyContactAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        Task<EmergencyContactDetailDto> GetAsync(Guid employeeId, Guid emergencyContactId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<EmergencyContactListDto>> GetListAsync(Guid employeeId, GetEmergencyContactsInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        Task<GetEmergencyContactForEditorOutput> GetEditorAsync(Guid employeeId, Guid emergencyContactId);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EmergencyContactListDto> CreateAsync(Guid employeeId, EmergencyContactCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EmergencyContactListDto> UpdateAsync(Guid employeeId, Guid emergencyContactId, EmergencyContactUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid employeeId, Guid emergencyContactId);
    }
}