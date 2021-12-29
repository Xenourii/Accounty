using Accounty.Business.Database.Models;
using AutoMapper;

namespace Accounty.Api.Profiles;

public class BaseEntityProfile : Profile
{
    public BaseEntityProfile()
    {
        CreateMap<Models.BaseEntity, BaseEntity>()
            .ForMember(a => a.CreatedDate, opt => opt.Ignore());
        CreateMap<BaseEntity, Models.BaseEntity>();
    }
}