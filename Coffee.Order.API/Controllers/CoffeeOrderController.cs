using Coffee.Order.Application.DTO.Request;
using Coffee.Order.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeOrderController : ControllerBase
    {
        private readonly ICoffeeOrderService _coffeeOrderService;

        public CoffeeOrderController(ICoffeeOrderService coffeeOrderService)
        {
            _coffeeOrderService = coffeeOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCoffeeOrderRequest request)
        {
            var response = await _coffeeOrderService.Create(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByCode(Guid id)
        {
            var response = await _coffeeOrderService.GetById(id);

            return Ok(response);
        }

        [HttpGet("{name}/name")]
        public async Task<IActionResult> GetAllByCode(string name)
        {
            var response = await _coffeeOrderService.GetByName(name);

            return Ok(response);
        }

        [HttpPatch("SetCompleted")]
        public async Task<IActionResult> SetCompleted(Guid id)
        {
            await _coffeeOrderService.SetCompleted(id);

            return NoContent();
        }
    }
}
