using AutoMapper;
using SneakerMarket.Api.Dto.Contact;
using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Dto
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Models.Account, UserDto>()
            .ForMember(m => m.City, opt =>
            {
                opt.PreCondition(x => x.CustomerInfo != null);
                opt.MapFrom(x => x.CustomerInfo.City);
            })
            .ForMember(m => m.CustomerDiscount, opt => {
                opt.PreCondition(x => x.CustomerInfo != null);
                opt.MapFrom(x => x.CustomerInfo.CustomerDiscount);
             })
            .ForMember(m => m.Name, opt => opt.MapFrom(x => x.Contacts.ToList()[0].Name))
            .ForMember(m => m.Surname, opt => opt.MapFrom(x => x.Contacts.ToList()[0].Surname))
            .ForMember(m => m.PhoneNumber, opt => opt.MapFrom(x => x.Contacts.ToList()[0].PhoneNumber))
            .ForMember(m => m.ContactId, opt => opt.MapFrom(x => x.Contacts.ToList()[0].Id))
            .ForMember(m => m.AccountId, opt => opt.MapFrom(x => x.Id))
            .ForMember(m => m.RoleId, opt => opt.MapFrom(x => x.RoleId))
            .ForMember(m => m.Email, opt => opt.MapFrom(x => x.Email));
        }
    }
}
