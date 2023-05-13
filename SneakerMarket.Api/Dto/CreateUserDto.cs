using SneakerMarket.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace SneakerMarket.Api.Dto
{
    public class CreateUserDto
    {
        //AccountPart
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        //ContactPart
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Surname { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        //CustomerInfoPart
        public string? City { get; set; }
    }
}
