using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snow.Hcm.EmployeeManagement.Positions;
using Snow.Hcm.EmployeeManagement.Positions.Dtos;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.Controllers.Positions
{
    /// <summary>
    /// 岗位
    /// </summary>
    [Route("api/positions")]
    public class PositionController : HcmController, IPositionAppService
    {
        private readonly IPositionAppService _positionAppService;

        public PositionController(IPositionAppService positionAppService)
        {
            _positionAppService = positionAppService;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<PositionDetailDto> GetAsync(System.Guid id)
        {
            return await _positionAppService.GetAsync(id);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<PositionListDto>> GetListAsync(GetPositionsInput input)
        {
            return await _positionAppService.GetListAsync(input);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="departmentId">部门Id</param>
        /// <returns></returns>
        [HttpGet("department/{departmentId}")]
        public async Task<ListResultDto<PositionListDto>> GetListAsync(Guid departmentId)
        {
            return await _positionAppService.GetListAsync(departmentId);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet("{id}/editor")]
        public virtual async Task<GetPositionForEditorOutput> GetEditorAsync(System.Guid id)
        {
            return await _positionAppService.GetEditorAsync(id);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<PositionListDto> CreateAsync(PositionCreateDto input)
        {
            return await _positionAppService.CreateAsync(input);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public virtual async Task<PositionListDto> UpdateAsync(System.Guid id, PositionUpdateDto input)
        {
            return await _positionAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task DeleteAsync(System.Guid id)
        {
            await _positionAppService.DeleteAsync(id);
        }
    }
}
