using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaystackIntegrateAPI.Service;

namespace PaystackIntegrateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaystackController : ControllerBase
    {
        private readonly IPaystackService _paystackService;

        public PaystackController(IPaystackService paystackService)
        {
            _paystackService = paystackService;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyPayment(string reference)
        {
            var res = await _paystackService.VerifyPayment(reference);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
