
using Apps.Models.Message;
using Apps.Models.Request;
using MassTransit;
using Newtonsoft.Json;

namespace Apps.Services
{
    public class WorkerService : IConsumer<DataMessage>
    {
        private readonly ICrudService _crudService;

        public WorkerService(ICrudService crudService)
        {
            _crudService = crudService;
        }

        public async Task Consume(ConsumeContext<DataMessage> context)
        {
            if (context.Message is null || context.Message.Command is null || context.Message.Data is null)
                return;

            if(string.Equals(context.Message.Command, "create", StringComparison.InvariantCultureIgnoreCase))
            {
                PostCrudRequest? request = JsonConvert.DeserializeObject<PostCrudRequest>(context.Message.Data);

                if (request is null)
                    return;

                await _crudService.AddData(request);
            }

            if (string.Equals(context.Message.Command, "edit", StringComparison.InvariantCultureIgnoreCase))
            {
                PutCrudRequest? request = JsonConvert.DeserializeObject<PutCrudRequest>(context.Message.Data);

                if (request is null)
                    return;

                await _crudService.EditData(request);
            }

            if (string.Equals(context.Message.Command, "delete", StringComparison.InvariantCultureIgnoreCase))
            {
                int id = Convert.ToInt32(context.Message.Data);

                await _crudService.DeleteData(id);
            }

        }
    }
}
