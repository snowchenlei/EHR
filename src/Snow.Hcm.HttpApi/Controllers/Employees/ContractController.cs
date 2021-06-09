using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.EmployeeManagement.Contracts;
using Snow.Hcm.EmployeeManagement.Contracts.Dtos;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.Controllers.Employees
{
    /// <summary>
    /// 合同
    /// </summary>
    [Route("api/employee/{employeeId}/contract")]
    public class ContractController : HcmController, IContractAppService
    {
        private readonly IContractAppService _contractAppService;

        public ContractController(IContractAppService contractAppService)
        {
            _contractAppService = contractAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        [HttpGet("{contractId}")]
        public virtual async Task<ContractDetailDto> GetAsync(Guid employeeId, Guid contractId)
        {
            return await _contractAppService.GetAsync(employeeId, contractId);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<ContractListDto>> GetListAsync(Guid employeeId, GetContractsInput input)
        {
            return await _contractAppService.GetListAsync(employeeId, input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        [HttpGet("{contractId}/editor")]
        public virtual async Task<GetContractForEditorOutput> GetEditorAsync(Guid employeeId, Guid contractId)
        {
            return await _contractAppService.GetEditorAsync(employeeId, contractId);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ContractListDto> CreateAsync(Guid employeeId, ContractCreateDto input)
        {
            return await _contractAppService.CreateAsync(employeeId, input);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{contractId}")]
        public virtual async Task<ContractListDto> UpdateAsync(Guid employeeId, Guid contractId, ContractUpdateDto input)
        {
            return await _contractAppService.UpdateAsync(employeeId, contractId, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        [HttpDelete("{contractId}")]
        public virtual async Task DeleteAsync(Guid employeeId, Guid contractId)
        {
            await _contractAppService.DeleteAsync(employeeId, contractId);
        }
    }
}
