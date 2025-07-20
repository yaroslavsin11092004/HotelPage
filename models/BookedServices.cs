using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Models
{
	[Table("BookedServices", Schema = "Essence")]
	public class BookedServices
	{
		[Column("id")][Key]
		public long id {get; set;}
		[Column("Quantity")]
		public decimal Quantity{get;set;}
		[Column("Date")]
		public DateTimeOffset Date{get;set;}
		[Column("BookingsId")][ForeignKey("Bookings")]
		public long BookingsId{get;set;}
		[Required]
		public Bookings Bookings{get;set;} = new Bookings();
		[Column("ServicesId")][ForeignKey("Services")]
		public long ServicesId{get;set;}
		[Required]
		public  Services Services{get;set;} = new Services();
	}
}
