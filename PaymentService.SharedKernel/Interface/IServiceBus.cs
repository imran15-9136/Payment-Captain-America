using PaymentService.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.SharedKernel.Interface
{
	public interface IServiceBus
	{
		Task PublishAsync(IPaymentRequestCommand model);
	}
}
