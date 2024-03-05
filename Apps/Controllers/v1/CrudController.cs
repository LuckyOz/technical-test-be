using Apps.Configs;
using Apps.Models.Request;
using Apps.Models.Response;
using Apps.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Apps.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ICrudService _crudService;
        private readonly IOptions<AppConfig> _appConfig;
        private readonly ILogger<CrudController> _logger;

        public CrudController(ICrudService crudService, IOptions<AppConfig> appConfig, ILogger<CrudController> logger)
        {
            _crudService = crudService;
            _appConfig = appConfig;
            _logger = logger;
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

        [HttpPost("add_data")]
        public async Task<ActionResult<ServiceResponse<CrudResponse>>> AddData(PostCrudRequest dataRequest)
        {
            var (data, dataStatus, dataMessage) = await _crudService.AddData(dataRequest);

            if (!dataStatus)
            {
                _logger.LogError($"Error Add Data, {dataMessage}, Request : {JsonConvert.SerializeObject(dataRequest)}");

                return NotFound(new ServiceResponse<CrudResponse>()
                {
                    Message = dataMessage,
                    Success = false,
                });
            }

            _logger.LogInformation($"Success Add Data, Request : {JsonConvert.SerializeObject(dataRequest)}");

            return Ok(new ServiceResponse<CrudResponse>()
            {
                Data = data,
            });
        }

        [HttpPut("edit_data")]
        public async Task<ActionResult<ServiceResponse<CrudResponse>>> EditData(PutCrudRequest dataRequest)
        {
            var (data, dataStatus, dataMessage) = await _crudService.EditData(dataRequest);

            if (!dataStatus)
            {
                _logger.LogError($"Error Edit Data, {dataMessage}, Request : {JsonConvert.SerializeObject(dataRequest)}");

                return NotFound(new ServiceResponse<CrudResponse>()
                {
                    Message = dataMessage,
                    Success = false,
                });
            }

            _logger.LogInformation($"Success Edit Data, Request : {JsonConvert.SerializeObject(dataRequest)}");

            return Ok(new ServiceResponse<CrudResponse>()
            {
                Data = data,
            });
        }

        [HttpDelete("delete_data/{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteData(int id)
        {
            var (dataStatus, dataMessage) = await _crudService.DeleteData(id);

            if (!dataStatus)
            {
                _logger.LogError($"Error Delete Data, {dataMessage}, Request : {id}");

                return NotFound(new ServiceResponse<string>()
                {
                    Message = dataMessage,
                    Success = false,
                });
            }

            _logger.LogInformation($"Success Delete Data, Request : {id}");

            return Ok(new ServiceResponse<string>()
            {
                Data = "Success Delete Data !!",
            });
        }
    }
}
