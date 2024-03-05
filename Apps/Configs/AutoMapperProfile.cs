
using Apps.Models.Db;
using Apps.Models.Request;
using Apps.Models.Response;
using AutoMapper;

namespace Apps.Configs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Test01, CrudResponse>();
            CreateMap<PostCrudRequest, Test01>();
        }
    }
}
