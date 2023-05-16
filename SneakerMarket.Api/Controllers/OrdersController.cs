using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using SneakerMarket.Api.Dto.Account;
using SneakerMarket.Api.Dto.Contact;
using SneakerMarket.Api.Dto;
using SneakerMarket.Api.Models;
using SneakerMarket.Api.Dto.FeedbackDto;
using SneakerMarket.Api.Dto.CustomerOrderDto;

namespace SneakerMarket.Api.Controllers
{
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private readonly IRepositoryWrapper _wrapperRepository;
        private readonly IMapper _mapper;

        public OrdersController(IRepositoryWrapper accountRepository, IMapper mapper)
        {
            _wrapperRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _wrapperRepository.CustomerOrder.GetCustomerOrderByIdAsync(id);
            if(order == null)
                return NotFound();

            var orderDto = _mapper.Map<CustomerGetOrderDto>(order);
            return Ok(orderDto);
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetAllCustomerOrdersByCustomerAccountId([FromRoute] Guid customerAccountId)
        {
            var orders = await _wrapperRepository.CustomerOrder.GetAllCustomerOrdersWithDetailsAsync(customerAccountId);

            return Ok(orders);
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> CreateFeedback([FromBody] FeedbackDto feedbackDto)
        {
            var account = await _wrapperRepository.Account
                .GetAccountByEmailWithDetailsAsync(feedbackDto.Email);

            if (account != null)
            {
                return BadRequest("Account is not founded.");
            }

            var feedback = _mapper.Map<Feedback>(feedbackDto);
            feedback.CustomerContactId = account.Contacts.ToList()[0].Id;

            _wrapperRepository.Feedback.CreateFeedback(feedback);

            try
            {
                await _wrapperRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok("feedback created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccountById([FromRoute] Guid id)
        {
            var feedback = await _wrapperRepository.Feedback
                .GetFeedbackAsync(id);

            if (feedback == null)
            {
                return BadRequest("There is no feedback with this id.");
            }

            _wrapperRepository.Feedback.DeleteFeedback(feedback);

            await _wrapperRepository.SaveAsync();

            return Ok("feedback deleted");
        }
    }
}
