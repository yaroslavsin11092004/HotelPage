using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Models
{
	[Table("Services", Schema = "Essence")]
	public class Services
	{
		[Column("Title")]
		public string? Title{get;set;}
		[Column("Price")]
		public decimal Price{get;set;}
		[Column("Type")]
		public string? Type{get;set;}
		[Column("id")][Key]
		public long id{get;set;}
		[Required]
		public List<Bookings> Bookings{get;set;} = new List<Bookings>();
	}
}
