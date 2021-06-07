using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

using Snow.Hcm.EmployeeManagement.Salaries;using Snow.Hcm.EmployeeManagement.Salaries.Dtos;

namespace Snow.Hcm.Controllers
{
    /// <summary>
    /// 工资
    /// </summary>
    public class SalaryController : HcmController, ISalaryAppService
    {
        private readonly ISalaryAppService _salaryAppService;

        public SalaryController(ISalaryAppService salaryAppService)
        {
            _salaryAppService = salaryAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<SalaryDetailDto> GetAsync(Guid id)
        {
            return await _salaryAppService.GetAsync(id);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<SalaryListDto>> GetListAsync(GetSalarysInput input)
        {
            return await _salaryAppService.GetListAsync(input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}/editor")]
        public virtual async Task<GetSalaryForEditorOutput> GetEditorAsync(Guid id)
        {
            return await _salaryAppService.GetEditorAsync(id);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<SalaryListDto> CreateAsync(SalaryCreateDto input)
        {
            return await _salaryAppService.CreateAsync(input);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<SalaryListDto> UpdateAsync(Guid id, SalaryUpdateDto input)
        {
            return await _salaryAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _salaryAppService.DeleteAsync(id);
        }
    }
}
