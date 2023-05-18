using System.ComponentModel.DataAnnotations;

namespace SneakerMarket.Api.Dto.AccountDto
{
    public class AccountLoginDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
