using Apps.Configs;
using Apps.Models.Response;
using Apps.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Apps.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ICrudService _crudService;
        private readonly IOptions<AppConfig> _appConfig;

        public CrudController(ICrudService crudService, IOptions<AppConfig> appConfig)
        {
            _crudService = crudService;
            _appConfig = appConfig;
        }

        [HttpGet("get_data_list")]
        public async Task<ActionResult<ServiceResponse<List<CrudResponse>>>> GetDataList(int? page)
        {
            int pageCount = 1, pageSet = 1;

            var (data, dataStatus, dataMessage) = await _crudService.GetListData();

            if (!dataStatus)
                return NotFound(new ServiceResponse<List<CrudResponse>>()
                {
                    Data = data,
                    Message = dataMessage,
                    Success = false
                });

            if (data is not null && data.Count > 0)
            {
                page ??= 1;
                var pageCountCek = Math.Ceiling((decimal)data.Count / (decimal)_appConfig.Value.TotalShowPage);

                data = data.Skip(((int)page - 1) * _appConfig.Value.TotalShowPage!).Take(_appConfig.Value.TotalShowPage).ToList();

                pageSet = (int)page;
                pageCount = (int)pageCountCek;
            }

            return Ok(new ServiceResponse<List<CrudResponse>>()
            {
                Data = data,
                Pages = pageSet,
                TotalPages = pageCount
            });
        }

        [HttpGet("get_data_id/{id}")]
        public async Task<ActionResult<ServiceResponse<CrudResponse>>> GetDataById(int id)
        {
            var (data, dataStatus, dataMessage) = await _crudService.GetDataById(id);

            if (!dataStatus)
                return NotFound(new ServiceResponse<CrudResponse>()
                {
                    Message = dataMessage,
                    Success = false,
                });

            return Ok(new ServiceResponse<CrudResponse>()
            {
                Data = data,
            });
        }
    }
}
