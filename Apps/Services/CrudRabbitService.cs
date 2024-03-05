
using Apps.Models.Context;
using Apps.Models.Db;
using Apps.Models.Message;
using Apps.Models.Request;
using Apps.Models.Response;
using AutoMapper;
using MassTransit;
using Newtonsoft.Json;

namespace Apps.Services
{
    public interface ICrudRabbitService
    {
        Task<(bool, string)> AddData(PostCrudRequest dataRequest);
        Task<(bool, string)> EditData(PutCrudRequest dataRequest);
        Task<(bool, string)> DeleteData(int id);
    }

    public class CrudRabbitService : ICrudRabbitService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public CrudRabbitService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<(bool, string)> AddData(PostCrudRequest dataRequest)
        {
            try
            {
                DataMessage dataMessage = new()
                {
                    Command = "create",
                    Data = JsonConvert.SerializeObject(dataRequest)
                };

                await _publishEndpoint.Publish(dataMessage);

                return (true, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, $"Failed Add Data With Rabbit, {ex.Message}");
            }
        }

        public async Task<(bool, string)> EditData(PutCrudRequest dataRequest)
        {
            try
            {
                DataMessage dataMessage = new()
                {
                    Command = "edit",
                    Data = JsonConvert.SerializeObject(dataRequest)
                };

                await _publishEndpoint.Publish(dataMessage);

                return (true, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, $"Failed Edit Data With Rabbit, {ex.Message}");
            }
        }

        public async Task<(bool, string)> DeleteData(int id)
        {
            try
            {
                DataMessage dataMessage = new()
                {
                    Command = "delete",
                    Data = Convert.ToString(id)
                };

                await _publishEndpoint.Publish(dataMessage);

                return (true, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, $"Failed Delete Data With Rabbit, {ex.Message}");
            }
        }
    }
}
