namespace Dto
{
	public class RoomsDto
	{
		public long? id{get;set;}
		public required decimal Number{get;set;}
		public required string Type{get;set;}
		public required decimal CostPerNight{get;set;}
		public required decimal Capacity{get;set;}
	}
}
