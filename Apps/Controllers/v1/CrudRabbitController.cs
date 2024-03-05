using Apps.Models.Request;
using Apps.Models.Response;
using Apps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apps.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CrudRabbitController : ControllerBase
    {
        private readonly ICrudRabbitService _crudRabbitService;

        public CrudRabbitController(ICrudRabbitService crudRabbitService)
        {
            _crudRabbitService = crudRabbitService;
        }

        [HttpPost("add_data")]
        public async Task<ActionResult<ServiceResponse<string>>> AddData(PostCrudRequest dataRequest)
        {
            var (dataStatus, dataMessage) = await _crudRabbitService.AddData(dataRequest);

            if (!dataStatus)
                return NotFound(new ServiceResponse<string>()
                {
                    Message = dataMessage,
                    Success = false,
                });

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
                return NotFound(new ServiceResponse<string>()
                {
                    Message = dataMessage,
                    Success = false,
                });

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
                return NotFound(new ServiceResponse<string>()
                {
                    Message = dataMessage,
                    Success = false,
                });

            return Ok(new ServiceResponse<string>()
            {
                Data = "Success Send to Rabbit for Delete Data !!",
            });
        }
    }
}
