using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
	[Table("Bookings", Schema = "Essence")]
	public class Bookings
	{
		[Column("id")][Key]
		public long id{get;set;}
		[Column("DateArrived")]
		public DateTimeOffset DateArrived{get;set;}
		[Column("DateDeparture")]
		public DateTimeOffset DateDeparture{get;set;}
		[Column("Status")]
		public string? Status{get;set;}
		[Column("GuestId")][ForeignKey("Guests")]
		public long GuestId{get;set;}
		[Required]
		public  Guests Guest{get;set;} = new Guests();
		[Column("RoomId")][ForeignKey("Rooms")]
		public long RoomId{get;set;}
		[Required]
		public  Rooms Rooms{get;set;} = new Rooms();
		[Required]
		public List<Payments> Payment{get;set;} = new();
		[Required]
		public List<Services> Services{get;set;} = new();
	}
}
