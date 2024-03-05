using Apps.Models.Context;
using Apps.Models.Db;
using Apps.Models.Request;
using Apps.Models.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Apps.Services
{
    public interface ICrudService
    {
        Task<(List<CrudResponse>, bool, string)> GetListData();
        Task<(CrudResponse, bool, string)> GetDataById(int id);
        Task<(CrudResponse, bool, string)> AddData(PostCrudRequest dataRequest);
        Task<(CrudResponse, bool, string)> EditData(PutCrudRequest dataRequest);
        Task<(bool, string)> DeleteData(int id);
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

        public async Task<(CrudResponse, bool, string)> AddData(PostCrudRequest dataRequest)
        {
            try
            {
                Test01 dataInsert = _mapper.Map<Test01>(dataRequest);
                dataInsert.Created = DateTime.UtcNow;

                _dataDbContext.Test01.Add(dataInsert);
                await _dataDbContext.SaveChangesAsync();

                var(data, dataStatus, dataMsg) = await GetDataById(dataInsert.Id);

                return (data, dataStatus, dataMsg);

            } catch (Exception ex)
            {
                return (new CrudResponse(), false, $"Failed Add Data, {ex.Message}");
            }
        }

        public async Task<(CrudResponse, bool, string)> EditData(PutCrudRequest dataRequest)
        {
            try
            {
                Test01? cekDataDb = await _dataDbContext.Test01.FirstOrDefaultAsync(q => q.Id == dataRequest.Id);

                if (cekDataDb is null)
                    return (new CrudResponse(), false, $"Failed Edit Data, No Have Data with Id {dataRequest.Id}");

                cekDataDb.Status = dataRequest.Status;
                cekDataDb.Nama = dataRequest.Nama;
                cekDataDb.Updated = DateTime.UtcNow;

                await _dataDbContext.SaveChangesAsync();

                var (data, dataStatus, dataMsg) = await GetDataById(dataRequest.Id);

                return (data, dataStatus, dataMsg);

            } catch (Exception ex)
            {
                return (new CrudResponse(), false, $"Failed Edit Data, {ex.Message}");
            }
        }

        public async Task<(bool, string)> DeleteData(int id)
        {
            try
            {
                Test01? cekDataDb = await _dataDbContext.Test01.FirstOrDefaultAsync(q => q.Id == id);

                if (cekDataDb is null)
                    return (false, $"Failed Delete Data, No Have Data with Id {id}");

                _dataDbContext.Remove(cekDataDb);
                await _dataDbContext.SaveChangesAsync();

                return (true, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, $"Failed Delete Data, {ex.Message}");
            }
        }
    }
}
