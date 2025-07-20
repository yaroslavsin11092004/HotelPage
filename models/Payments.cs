using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
	[Table("Payments", Schema = "Essence")]
	public class Payments
	{
		[Column("id")][Key]
		public long id{get;set;}
		[Column("BookingsId")][ForeignKey("Bookings")]
		public long BookingsId{get;set;}
		[Column("Sum")]
		public decimal Sum{get;set;}
		[Column("DatePayment")]
		public DateTimeOffset DatePayment{get;set;}
		[Column("Method")]
		public string? Method{get;set;}
		[Required]
		public Bookings Booking{get;set;} = new Bookings();
	}
}
		
