namespace Dto
{
	public class BookedServiceDto
	{
		public long? id{get;set;}
		public required decimal Quantity{get;set;}
		public required DateTimeOffset Date{get;set;}
		public required long BookingsId{get;set;}
		public required long ServicesId{get;set;}
	}
}
