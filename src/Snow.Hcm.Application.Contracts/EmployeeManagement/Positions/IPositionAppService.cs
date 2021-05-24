using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Snow.Hcm.EmployeeManagement.Positions.Dtos;

namespace Snow.Hcm.EmployeeManagement.Positions
{
    /// <summary>
    /// 岗位管理
    /// </summary>
    public interface IPositionAppService: IApplicationService
    {
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<PositionDetailDto> GetAsync(Guid id);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<PositionListDto>> GetListAsync([NotNull] GetPositionsInput input);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <returns></returns>
        Task<ListResultDto<PositionListDto>> GetListAsync(Guid departmentId);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetPositionForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PositionListDto> CreateAsync([NotNull] PositionCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PositionListDto> UpdateAsync(Guid id, [NotNull] PositionUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}