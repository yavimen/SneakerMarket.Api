using System.ComponentModel.DataAnnotations;

namespace SneakerMarket.Api.Dto
{
    public class UserDto
    {
        //AccountPart
        public Guid AccountId { get; set; }
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public Guid RoleId { get; set; }

        //ContactPart
        public Guid ContactId { get; set; }
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        //CustomerInfoPart
        public string? City { get; set; }
        public float? CustomerDiscount { get; set; }
    }
}
