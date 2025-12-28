using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.SharedKernel.Dto
{
	public class PaymentRequestDto : IPaymentRequestCommand
	{
		public string TransactionId { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public string PaymentMethod { get; set; }
		public DateTime RequestDate { get; set; }
	}
}
