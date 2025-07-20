using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
	[Table("Rooms", Schema = "Essence")]
	public class Rooms
	{
		[Column("id")][Key]
		public long id{get;set;}
		[Column("Number")]
		public decimal Number{get;set;}
		[Column("Type")]
		public string? Type{get;set;}
		[Column("CostPerNight")]
		public decimal CostPerNight{get;set;}
		[Column("Capacity")]
		public decimal Capacity{get;set;}
		[Required]
		public List<Bookings> Bookings{get;set;} = new  List<Bookings>();
		[Required]
		public List<Staff> Staff{get;set;} = new List<Staff>();
	}
}
