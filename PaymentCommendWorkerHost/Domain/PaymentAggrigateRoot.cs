using PaymentService.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PaymentCommendWorkerHost.Domain
{
	internal class PaymentAggrigateRoot
	{
		public string Id { get; set; }
		public string TransactionId { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public string PaymentMethod { get; set; }
		public DateTime RequestDate { get; set; }
		public decimal CommissionAmount { get; set; }

		public bool CreatePayment(PaymentRequestDto model)
		{
			if (model.Amount < 100)
				return false;

			if(model.RequestDate < DateTime.Now)
				return false;

			TransactionId = model.TransactionId.ToString();
			Amount = model.Amount;
			Currency = model.Currency;
			PaymentMethod = model.PaymentMethod;
			RequestDate = model.RequestDate;
			CommissionAmount = CalculateCommission(model.Amount);
			Id = Guid.NewGuid().ToString();

			return true;
		}
		private decimal CalculateCommission(decimal amount)
		{
			if(amount <= 1000)
				return amount * 0.02m;
			else
				return amount * 0.015m;
		}

	}
}
