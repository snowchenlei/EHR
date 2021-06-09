using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Snow.Hcm.Permissions;
using Snow.Hcm.EmployeeManagement.Contracts.Dtos;

namespace Snow.Hcm.EmployeeManagement.Contracts
{
    /// <summary>
    /// 合同管理
    /// </summary>
    [Authorize(HcmPermissions.Contracts.Default)]
    public class ContractAppService : HcmAppService, IContractAppService
    {
        private readonly IRepository<Contract, Guid> _contractRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="contractRepository"></param>
        public ContractAppService(
            IRepository<Contract, Guid> contractRepository)
        {
            _contractRepository = contractRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        public virtual async Task<ContractDetailDto> GetAsync(Guid employeeId, Guid contractId)
        {
            Contract entity = await _contractRepository
                .GetAsync(c=>c.EmployeeId == employeeId && c.Id == contractId);

            return ObjectMapper.Map<Contract, ContractDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<ContractListDto>> GetListAsync(Guid employeeId, GetContractsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _contractRepository.GetQueryableAsync();

            queryable = queryable.Where(c => c.EmployeeId == employeeId);

             long totalCount = await AsyncExecuter.CountAsync(queryable);
            
            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? "Id DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Contract>, List<ContractListDto>>(entities);

            return new PagedResultDto<ContractListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        public virtual async Task<GetContractForEditorOutput> GetEditorAsync(Guid employeeId, Guid contractId)
        {
            Contract entity = await _contractRepository
                .GetAsync(c => c.EmployeeId == employeeId && c.Id == contractId);

            return ObjectMapper.Map<Contract, GetContractForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Contracts.Create)]
        public virtual async Task<ContractListDto> CreateAsync(Guid employeeId, ContractCreateDto input)
        {
            var entity = ObjectMapper.Map<ContractCreateDto, Contract>(input);
            entity.EmployeeId = employeeId;
            entity = await _contractRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Contract, ContractListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Contracts.Update)]
        public virtual async Task<ContractListDto> UpdateAsync(Guid employeeId, Guid contractId, ContractUpdateDto input)
        {
            Contract entity = await _contractRepository
                .GetAsync(c => c.EmployeeId == employeeId && c.Id == contractId);
            entity = ObjectMapper.Map(input, entity);
            entity = await _contractRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Contract, ContractListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="employeeId">员工Id</param>
        /// <param name="contractId">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Contracts.Delete)]
        public virtual async Task DeleteAsync(Guid employeeId, Guid contractId)
        {
            await _contractRepository.DeleteAsync(c => c.Id == contractId && c.EmployeeId == employeeId);
        }

        

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(ContractSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
