using AutoMapper;
using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Dto.Account
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateUserDto, SneakerMarket.Api.Models.Account>()
            .ForMember(m => m.Email, opt => opt.MapFrom(x => x.Email))
            .ForMember(m => m.Password, opt => opt.MapFrom(x => x.Password))
            .ForMember(m => m.RoleId, opt => opt.MapFrom(x => new Guid("1E68C911-8902-45E8-81D9-1F0453D4F86E")))
            .ForMember(m => m.Id, opt => opt.MapFrom(x =>Guid.NewGuid()));

            CreateMap<AccountUpdateDto, SneakerMarket.Api.Models.Account>()
            .ForMember(m => m.Email, opt => opt.UseDestinationValue())
            .ForMember(m => m.Password, opt => opt.MapFrom(x => x.Password))
            .ForMember(m => m.RoleId, opt => opt.UseDestinationValue())
            .ForMember(m => m.Id, opt => opt.UseDestinationValue());
        }
    }
}