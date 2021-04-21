using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.Controllers.Employees
{
    /// <summary>
    /// 紧急联络人管理
    /// </summary>
    [Route("api/employee/{employeeId}/emergency-contact")]
    public class EmergencyContactController:HcmController, IEmergencyContactAppService
    {
        private readonly IEmergencyContactAppService _emergencyContactAppService;

        public EmergencyContactController(IEmergencyContactAppService emergencyContactAppService)
        {
            _emergencyContactAppService = emergencyContactAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        [HttpGet("{emergencyContactId}")]
        public virtual async Task<EmergencyContactDetailDto> GetAsync(Guid employeeId, Guid emergencyContactId)
        {
            return await _emergencyContactAppService.GetAsync(employeeId, emergencyContactId);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<EmergencyContactListDto>> GetListAsync(Guid employeeId, GetEmergencyContactsInput input)
        {
            return await _emergencyContactAppService.GetListAsync(employeeId, input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        [HttpGet("{emergencyContactId}/editor")]
        public virtual async Task<GetEmergencyContactForEditorOutput> GetEditorAsync(Guid employeeId, Guid emergencyContactId)
        {
            return await _emergencyContactAppService.GetEditorAsync(employeeId, emergencyContactId);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<EmergencyContactListDto> CreateAsync(Guid employeeId, EmergencyContactCreateDto input)
        {
            return await _emergencyContactAppService.CreateAsync(employeeId, input);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{emergencyContactId}")]
        public virtual async Task<EmergencyContactListDto> UpdateAsync(Guid employeeId, Guid emergencyContactId, EmergencyContactUpdateDto input)
        {
            return await _emergencyContactAppService.UpdateAsync(employeeId, emergencyContactId, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="emergencyContactId">主键</param>
        /// <returns></returns>
        [HttpDelete("{emergencyContactId}")]
        public virtual async Task DeleteAsync(Guid employeeId, Guid emergencyContactId)
        {
            await _emergencyContactAppService.DeleteAsync(employeeId, emergencyContactId);
        }
    }
}
