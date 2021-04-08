using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

using Snow.Hcm.EmployeeManagement.Departments;using Snow.Hcm.EmployeeManagement.Departments.Dtos;

namespace Snow.Hcm.Controllers
{
    /// <summary>
    /// 部门
    /// </summary>
    public class DepartmentController : HcmController, IDepartmentAppService
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
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<DepartmentDetailDto> GetAsync(int id)
        {
            return await _departmentAppService.GetAsync(id);
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
        [HttpGet]
        [Route("{id}/editor")]
        public virtual async Task<GetDepartmentForEditorOutput> GetEditorAsync(int id)
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
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task<DepartmentListDto> UpdateAsync(int id, DepartmentUpdateDto input)
        {
            return await _departmentAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task DeleteAsync(int id)
        {
            await _departmentAppService.DeleteAsync(id);
        }
    }
}
