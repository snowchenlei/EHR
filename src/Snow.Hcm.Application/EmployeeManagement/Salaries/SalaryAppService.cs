using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Snow.Hcm.EmployeeManagement.Salaries.Dtos;
using Snow.Hcm.Permissions;

namespace Snow.Hcm.EmployeeManagement.Salaries
{
    /// <summary>
    /// 工资管理
    /// </summary>
    [Authorize(HcmPermissions.Salarys.Default)]
    public class SalaryAppService : HcmAppService, ISalaryAppService
    {
        private readonly IRepository<Salary, Guid> _salaryRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="salaryRepository"></param>
        public SalaryAppService(
            IRepository<Salary, Guid> salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<SalaryDetailDto> GetAsync(Guid id)
        {
            Salary entity = await _salaryRepository.GetAsync(id);

            return ObjectMapper.Map<Salary, SalaryDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<SalaryListDto>> GetListAsync(GetSalarysInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _salaryRepository.GetQueryableAsync();

             long totalCount = await AsyncExecuter.CountAsync(queryable);
            
            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? "Id DESC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Salary>, List<SalaryListDto>>(entities);

            return new PagedResultDto<SalaryListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetSalaryForEditorOutput> GetEditorAsync(Guid id)
        {
            Salary entity = await _salaryRepository.GetAsync(id);

            return ObjectMapper.Map<Salary, GetSalaryForEditorOutput>(entity);
        }
    
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Salarys.Create)]
        public virtual async Task<SalaryListDto> CreateAsync(SalaryCreateDto input)
        {
            var entity = ObjectMapper.Map<SalaryCreateDto, Salary>(input);
            entity = await _salaryRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Salary, SalaryListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Salarys.Update)]
        public virtual async Task<SalaryListDto> UpdateAsync(Guid id, SalaryUpdateDto input)
        {
            Salary entity = await _salaryRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _salaryRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Salary, SalaryListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Salarys.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _salaryRepository.DeleteAsync(s => s.Id == id);
        }

        

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(SalarySettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
