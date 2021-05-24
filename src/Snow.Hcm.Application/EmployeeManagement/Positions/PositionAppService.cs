using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Snow.Hcm.EmployeeManagement.Positions.Dtos;
using Snow.Hcm.Permissions;

namespace Snow.Hcm.EmployeeManagement.Positions
{
    /// <summary>
    /// 岗位管理
    /// </summary>
    [Authorize(HcmPermissions.Positions.Default)]
    public class PositionAppService : HcmAppService, IPositionAppService
    {
        private readonly IRepository<Position, Guid> _positionRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="positionRepository"></param>
        public PositionAppService(
            IRepository<Position, Guid> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<PositionDetailDto> GetAsync(Guid id)
        {
            Position entity = await _positionRepository.GetAsync(id);

            return ObjectMapper.Map<Position, PositionDetailDto>(entity);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<PositionListDto>> GetListAsync(GetPositionsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _positionRepository.GetQueryableAsync();

             long totalCount = await AsyncExecuter.CountAsync(queryable);

             var entities = await AsyncExecuter.ToListAsync(queryable
                 .Include(p => p.Department)
                 .OrderBy(input.Sorting ?? "Id DESC")
                 .Skip(input.SkipCount)
                 .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Position>, List<PositionListDto>>(entities);

            return new PagedResultDto<PositionListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <returns></returns>
        public async Task<ListResultDto<PositionListDto>> GetListAsync(Guid departmentId)
        {
            var positionQueryable = await _positionRepository.GetQueryableAsync();
            var positions = await AsyncExecuter.ToListAsync(positionQueryable
                .Where(p => p.DepartmentId == departmentId));
            return new ListResultDto<PositionListDto>(ObjectMapper.Map<List<Position>, List<PositionListDto>>(positions));
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetPositionForEditorOutput> GetEditorAsync(Guid id)
        {
            Position entity = await _positionRepository.GetAsync(id);

            return ObjectMapper.Map<Position, GetPositionForEditorOutput>(entity);
        }
    
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Positions.Create)]
        public virtual async Task<PositionListDto> CreateAsync(PositionCreateDto input)
        {
            var entity = ObjectMapper.Map<PositionCreateDto, Position>(input);
            entity = await _positionRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Position, PositionListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Positions.Update)]
        public virtual async Task<PositionListDto> UpdateAsync(Guid id, PositionUpdateDto input)
        {
            Position entity = await _positionRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _positionRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Position, PositionListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(HcmPermissions.Positions.Delete)]
        public virtual async Task DeleteAsync(System.Guid id)
        {
            await _positionRepository.DeleteAsync(s => s.Id == id);
        }

        

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(PositionSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
