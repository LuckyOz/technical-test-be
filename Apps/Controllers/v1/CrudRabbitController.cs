using Apps.Models.Request;
using Apps.Models.Response;
using Apps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Apps.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CrudRabbitController : ControllerBase
    {
        private readonly ICrudRabbitService _crudRabbitService;
        private readonly ILogger<CrudRabbitController> _logger;

        public CrudRabbitController(ICrudRabbitService crudRabbitService, ILogger<CrudRabbitController> logger)
        {
            _crudRabbitService = crudRabbitService;
            _logger = logger;
        }

        [HttpPost("add_data")]
        public async Task<ActionResult<ServiceResponse<string>>> AddData(PostCrudRequest dataRequest)
        {
            var (dataStatus, dataMessage) = await _crudRabbitService.AddData(dataRequest);

            if (!dataStatus)
            {
                _logger.LogError($"Error Add Data Send to RabbitMq, {dataMessage}, Request : {JsonConvert.SerializeObject(dataRequest)}");

                return NotFound(new ServiceResponse<string>()
                {
                    Message = dataMessage,
                    Success = false,
                });
            }

            _logger.LogInformation($"Success Add Data Send to RabbitMq, Request : {JsonConvert.SerializeObject(dataRequest)}");

            return Ok(new ServiceResponse<string>()
            {
                Data = "Success Send to Rabbit for Add Data !!",
            });
        }

        [HttpPut("edit_data")]
        public async Task<ActionResult<ServiceResponse<string>>> EditData(PutCrudRequest dataRequest)
        {
            var (dataStatus, dataMessage) = await _crudRabbitService.EditData(dataRequest);

            if (!dataStatus)
            {
                _logger.LogError($"Error Edit Data Send to RabbitMq, {dataMessage}, Request : {JsonConvert.SerializeObject(dataRequest)}");

                return NotFound(new ServiceResponse<string>()
                {
                    Message = dataMessage,
                    Success = false,
                });
            }

            _logger.LogInformation($"Success Edit Data Send to RabbitMq, Request : {JsonConvert.SerializeObject(dataRequest)}");

            return Ok(new ServiceResponse<string>()
            {
                Data = "Success Send to Rabbit for Edit Data !!",
            });
        }

        [HttpDelete("delete_data/{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteData(int id)
        {
            var (dataStatus, dataMessage) = await _crudRabbitService.DeleteData(id);

            if (!dataStatus)
            {
                _logger.LogError($"Error Delete Data Send to RabbitMq, {dataMessage}, Request : {id}");

                return NotFound(new ServiceResponse<string>()
                {
                    Message = dataMessage,
                    Success = false,
                });
            }

            _logger.LogInformation($"Success Delete Data Send to RabbitMq, Request : {id}");

            return Ok(new ServiceResponse<string>()
            {
                Data = "Success Send to Rabbit for Delete Data !!",
            });
        }
    }
}
