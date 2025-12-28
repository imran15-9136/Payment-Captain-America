using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.SharedKernel.Dto
{
	public class PaymentCancelDto : IPaymentRequestCommand
	{
		public string TransactionId { get; set; }
		public DateTime CancelDate { get; set; }
	}
}
