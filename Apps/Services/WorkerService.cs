
using Apps.Models.Message;
using Apps.Models.Request;
using MassTransit;
using Newtonsoft.Json;

namespace Apps.Services
{
    public class WorkerService : IConsumer<DataMessage>
    {
        private readonly ICrudService _crudService;
        private readonly ILogger<WorkerService> _logger;

        public WorkerService(ICrudService crudService, ILogger<WorkerService> logger)
        {
            _crudService = crudService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DataMessage> context)
        {
            if (context.Message is null || context.Message.Command is null || context.Message.Data is null)
                return;

            if(string.Equals(context.Message.Command, "create", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    PostCrudRequest? request = JsonConvert.DeserializeObject<PostCrudRequest>(context.Message.Data);

                    if (request is null)
                        return;

                    var(data, dataStatus, dataMsg) = await _crudService.AddData(request);

                    if (!dataStatus)
                        _logger.LogError($"Error Consume Create, {dataMsg}, Request : {JsonConvert.SerializeObject(request)}");

                    _logger.LogInformation($"Success Consume Create, Request : {JsonConvert.SerializeObject(request)}");

                } catch (Exception ex)
                {
                    _logger.LogError($"Error Consume Create, {ex.Message}, {context.Message.Data}");
                }
                
            }

            if (string.Equals(context.Message.Command, "edit", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    PutCrudRequest? request = JsonConvert.DeserializeObject<PutCrudRequest>(context.Message.Data);

                    if (request is null)
                        return;

                    var (data, dataStatus, dataMsg) = await _crudService.EditData(request);

                    if (!dataStatus)
                        _logger.LogError($"Error Consume Edit, {dataMsg}, Request : {JsonConvert.SerializeObject(request)}");

                    _logger.LogInformation($"Success Consume Edit, Request : {JsonConvert.SerializeObject(request)}");
                } catch (Exception ex)
                {
                    _logger.LogError($"Error Consume Edit, {ex.Message},  {context.Message.Data}");
                }
            }

            if (string.Equals(context.Message.Command, "delete", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    int id = Convert.ToInt32(context.Message.Data);

                    var (dataStatus, dataMsg) = await _crudService.DeleteData(id);

                    if (!dataStatus)
                        _logger.LogError($"Error Consume Delete, {dataMsg}, Request : {id}");

                    _logger.LogInformation($"Success Consume Delete, Request : {id}");
                } catch (Exception ex)
                {
                    _logger.LogError($"Error Consume Delete, {ex.Message}, {context.Message.Data}");
                }
            }

        }
    }
}
