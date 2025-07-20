namespace Dto
{
	public class BookingsDto
	{
		public long id{get;set;}
		public DateTimeOffset DateArrived{get;set;}
		public DateTimeOffset DateDeparture{get;set;}
		public decimal NumberRoom{get;set;}
		public string? Name{get;set;}
		public string? Surname{get;set;}
		public string? Status{get;set;}
	}	
}
