using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.SharedKernel.Dto;
using PaymentService.SharedKernel.Interface;

namespace PaymentService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController(IServiceBus _service) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> MakePayment([FromBody] PaymentRequestDto model)
		{
			try
			{
				await _service.PublishAsync(model);
				return Ok("Payment request submitted successfully.");
			}
			catch(Exception ex)
			{
				// Log the exception (not implemented here for brevity)
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the payment request.");
			}
	
		}

		[HttpPatch]
		public async Task<IActionResult> UpdatePayment([FromBody] PaymentCancelDto model)
		{
			try
			{
				await _service.PublishAsync(model);
				return Ok("Payment update request submitted successfully.");
			}
			catch (Exception ex)
			{
				// Log the exception (not implemented here for brevity)
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the payment update request.");
			}
		}
	}
}
