using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Snow.Hcm.EmployeeManagement.Contracts.Dtos;

namespace Snow.Hcm.EmployeeManagement.Contracts
{
    /// <summary>
    /// 合同管理
    /// </summary>
    public interface IContractAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        Task<ContractDetailDto> GetAsync(Guid employeeId, Guid contractId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<ContractListDto>> GetListAsync(Guid employeeId, GetContractsInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        Task<GetContractForEditorOutput> GetEditorAsync(Guid employeeId, Guid contractId);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ContractListDto> CreateAsync(Guid employeeId, ContractCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ContractListDto> UpdateAsync(Guid employeeId, Guid contractId, ContractUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid employeeId, Guid contractId);
    }
}