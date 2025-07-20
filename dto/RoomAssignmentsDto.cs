namespace Dto
{
	public class RoomAssignmentsDto
	{
		public long? id{get;set;}
		public required DateTimeOffset Date{get;set;}
		public required long RoomId{get;set;}
		public required long StaffId{get;set;}
	}
}
