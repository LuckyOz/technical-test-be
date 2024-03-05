using Apps.Models.Context;
using Apps.Models.Db;
using Apps.Models.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apps.Services
{
    public interface ICrudService
    {
        Task<(List<CrudResponse>, bool, string)> GetListData();
        Task<(CrudResponse, bool, string)> GetDataById(int id);
    }

    public class CrudService : ICrudService
    {
        private readonly DataDbContext _dataDbContext;
        private readonly IMapper _mapper;

        public CrudService(DataDbContext dataDbContext, IMapper mapper)
        {
            _dataDbContext = dataDbContext;
            _mapper = mapper;
        }

        public async Task<(List<CrudResponse>, bool, string)> GetListData()
        {
            try
            {
                List<Test01> dataDb = await _dataDbContext.Test01.ToListAsync();

                if (dataDb is null || dataDb.Count < 1)
                    return (new List<CrudResponse>(), true, "SUCCESS");

                return (_mapper.Map<List<CrudResponse>>(dataDb), true, "SUCCESS"); 

            } catch (Exception ex)
            {
                return (new List<CrudResponse>(), false, ex.Message);
            }
        }

        public async Task<(CrudResponse, bool, string)> GetDataById(int id)
        {
            try
            {
                Test01? dataDb = await _dataDbContext.Test01.FirstOrDefaultAsync(q => q.Id == id);

                if (dataDb is null)
                    return (new CrudResponse(), false, $"Data db with Id {id} is empty");

                return (_mapper.Map<CrudResponse>(dataDb), true, "SUCCESS");

            } catch (Exception ex)
            {
                return (new CrudResponse(), false, ex.Message);
            }
        }
    }
}
