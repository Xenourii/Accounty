using Accounty.Business.Database.Models;
using AutoMapper;
using Dto = Accounty.Api.Models;

namespace Accounty.Api.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Dto.Account, Account>()
            .ForMember(a => a.Id, opt => opt.Ignore());
        CreateMap<Account, Dto.Account>();
    }
}