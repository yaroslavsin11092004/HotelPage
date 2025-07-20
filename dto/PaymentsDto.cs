namespace Dto
{
	public class PaymentsDto
	{
		public long? id{get;set;}
		public required long BookingsId{get;set;}
		public required decimal Sum{get;set;}
		public required DateTimeOffset DatePayment{get;set;}
		public required string Method{get;set;}
	}
}
