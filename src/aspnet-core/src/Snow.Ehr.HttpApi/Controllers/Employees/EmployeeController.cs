using Microsoft.AspNetCore.Mvc;
using Snow.Ehr.EmployeeManagement.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.Controllers.Employees
{
    /// <summary>
    /// 员工管理
    /// </summary>
    [Route("api/employee")]
    public class EmployeeController:EhrController,IEmployeeAppService
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<EmployeeDetailDto> GetAsync(Guid id)
        {
            return await _employeeAppService.GetAsync(id);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<EmployeeListDto>> GetListAsync(GetEmployeesInput input)
        {
            return await _employeeAppService.GetListAsync(input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}/editor")]
        public virtual async Task<GetEmployeeForEditorOutput> GetEditorAsync(Guid id)
        {
            return await _employeeAppService.GetEditorAsync(id);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<EmployeeListDto> CreateAsync(EmployeeCreateDto input)
        {
            return await _employeeAppService.CreateAsync(input);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<EmployeeListDto> UpdateAsync(Guid id, EmployeeUpdateDto input)
        {
            return await _employeeAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _employeeAppService.DeleteAsync(id);
        }
    }
}
