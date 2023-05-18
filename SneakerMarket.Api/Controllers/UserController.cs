using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using SneakerMarket.Api.Dto;
using SneakerMarket.Api.Dto.Account;
using SneakerMarket.Api.Dto.AccountDto;
using SneakerMarket.Api.Dto.Contact;
using SneakerMarket.Api.Models;

namespace SneakerMarket.Api.Controllers
{
    [Route("api/account")]
    public class UserController : Controller
    {
        private readonly IRepositoryWrapper _wrapperRepository;
        private readonly IMapper _mapper;

        public UserController(IRepositoryWrapper accountRepository, IMapper mapper)
        {
            _wrapperRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserAccount(string email)
        {
            var account = await _wrapperRepository.Account.GetAccountByEmailAsync(email);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetUserAccount([FromBody] AccountLoginDto loginDto)
        {
            var account = await _wrapperRepository.Account.GetAccountByEmailAsync(loginDto.Email);

            if (account == null)
            {
                return NotFound("User not found");
            }

            if (loginDto.Password != account.Password) 
            {
                return BadRequest("Wrong password");
            }

            return Ok(account);
        }

        [HttpGet("details/{email}")]
        public async Task<IActionResult> GetUserAccountWithDetails(string email)
        {
            var account = await _wrapperRepository.Account.GetAccountByEmailWithDetailsAsync(email);

            if (account == null)
            {
                return NotFound();
            }

            var accountDto = _mapper.Map<UserDto>(account);

            return Ok(accountDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAccount([FromBody] CreateUserDto accountDto)
        {
            var existingAccount = await _wrapperRepository.Account
                .GetAccountByEmailAsync(accountDto.Email);

            if (existingAccount != null)
            {
                return BadRequest("This email already registrated.");
            }

            var account = _mapper.Map<Account>(accountDto);
            var contact = _mapper.Map<Contact>(accountDto);
            var customerInfo = _mapper.Map<CustomerInfo>(accountDto);

            contact.AccountId = account.Id;
            customerInfo.CustomerAccountId = account.Id;

            _wrapperRepository.Account.CreateAccount(account);
            _wrapperRepository.Contact.CreateContact(contact);
            _wrapperRepository.CustomerInfo.CreateCustomerInfo(customerInfo);
            try
            {
                await _wrapperRepository.SaveAsync();
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
            return Ok("user created");
        }

        [HttpPut("change-contact/{email}")]
        public async Task<IActionResult> UpdateUserContact([FromRoute] string email, [FromBody] ContactUpdateDto contactDto)
        {
            var existingAccount = await _wrapperRepository.Account
                .GetAccountByEmailAsync(email);

            if (existingAccount == null) 
            {
                return BadRequest("There is no account with this email.");
            }

            var contact = await _wrapperRepository.Contact
                .GetContactByAccountIdAsync(existingAccount.Id);

            var customerInfo = await _wrapperRepository.CustomerInfo
                .GetCustomerInfoByIdAsync(existingAccount.Id);

            if (contact == null || customerInfo == null)
                return StatusCode(500, "Internal server error.");

            _mapper.Map(contactDto, contact);
            _mapper.Map(contactDto, customerInfo);

            _wrapperRepository.Contact.UpdateContact(contact);
            _wrapperRepository.CustomerInfo.UpdateCustomerInfo(customerInfo);

            await _wrapperRepository.SaveAsync();

            return Ok("contact updated");
        }      

        [HttpPut("change-password/{email}")]
        public async Task<IActionResult> UpdateUserPassword([FromRoute] string email, [FromBody] AccountUpdateDto accountDto)
        {
            var existingAccount = await _wrapperRepository.Account
                .GetAccountByEmailAsync(email);

            if (existingAccount == null) 
            {
                return BadRequest("There is no account with this email.");
            }

            _mapper.Map(accountDto, existingAccount);

            _wrapperRepository.Account.UpdateAccount(existingAccount);

            await _wrapperRepository.SaveAsync();

            return Ok("password updated");
        }        
        
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUserAccountByEmail([FromRoute] string email)
        {
            var existingAccount = await _wrapperRepository.Account
                .GetAccountByEmailAsync(email);

            if (existingAccount == null) 
            {
                return BadRequest("There is no account with this email.");
            }

            var contact = await _wrapperRepository.Contact
                .GetContactByAccountIdAsync(existingAccount.Id);

            var customerInfo = await _wrapperRepository.CustomerInfo
                .GetCustomerInfoByIdAsync(existingAccount.Id);

            if (contact == null || customerInfo == null)
                return StatusCode(500, "Internal server error.");

            _wrapperRepository.Account.DeleteAccount(existingAccount);

            _wrapperRepository.Contact.DeleteContact(contact);
            
            _wrapperRepository.CustomerInfo.DeleteCustomerInfo(customerInfo);

            await _wrapperRepository.SaveAsync();

            return Ok("user deleted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAccounts(string email)
        {
            var accounts = await _wrapperRepository.Account.GetAllAccountsAsync();

            return Ok(accounts);
        }
    }
}
