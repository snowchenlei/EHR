using System;
using System.Threading.Tasks;
using Snow.Ehr.EmployeeManagement.Salaries;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Snow.Ehr.EmployeeManagement.Salaries
{
    /// <summary>
    /// 工资管理
    /// </summary>
    public interface ISalaryAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<SalaryDetailDto> GetAsync(Guid id);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<SalaryListDto>> GetListAsync(GetSalarysInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetSalaryForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<SalaryListDto> CreateAsync(SalaryCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<SalaryListDto> UpdateAsync(Guid id, SalaryUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}