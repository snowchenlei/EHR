using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;

namespace Snow.Hcm.EmployeeManagement.Employees
{
    /// <summary>
    /// 员工管理
    /// </summary>
    public interface IEmployeeAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<EmployeeDetailDto> GetAsync(Guid id);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<EmployeeListDto>> GetListAsync(GetEmployeesInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetEmployeeForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EmployeeListDto> CreateAsync(EmployeeCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<EmployeeListDto> UpdateAsync(Guid id, EmployeeUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}