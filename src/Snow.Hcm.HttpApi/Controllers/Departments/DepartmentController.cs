using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Departments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.Controllers.Departments
{
    /// <summary>
    /// 部门管理
    /// </summary>
    [Route("api/department")]
    public class DepartmentController:HcmController,IDepartmentAppService
    {
        private readonly IDepartmentAppService _departmentAppService;

        public DepartmentController(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<DepartmentDetailDto> GetAsync(Guid id)
        {
            return await _departmentAppService.GetAsync(id);
        }

        /// <summary>
        /// 所有
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public virtual async Task<ListResultDto<DepartmentListDto>> GetAllListAsync()
        {
            return await _departmentAppService.GetAllListAsync();
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<DepartmentListDto>> GetListAsync(GetDepartmentsInput input)
        {
            return await _departmentAppService.GetListAsync(input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}/editor")]
        public virtual async Task<GetDepartmentForEditorOutput> GetEditorAsync(Guid id)
        {
            return await _departmentAppService.GetEditorAsync(id);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<DepartmentListDto> CreateAsync(DepartmentCreateDto input)
        {
            return await _departmentAppService.CreateAsync(input);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<DepartmentListDto> UpdateAsync(Guid id, DepartmentUpdateDto input)
        {
            return await _departmentAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _departmentAppService.DeleteAsync(id);
        }
    }
}
