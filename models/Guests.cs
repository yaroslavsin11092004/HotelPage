using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
	[Table("Guests", Schema = "Essence")]
	public class Guests
	{
		[Column("Name")]
		public string? Name{get;set;}
		[Column("Surname")]
		public string? Surname{get;set;}
		[Column("Phone")]
		public string? Phone{get;set;}
		[Column("Email")]
		public string? Email{get;set;}
		[Column("id")][Key]
		public long id{get;set;}
		[Column("RegData")]
		public DateTimeOffset RegData{get;set;}
		[Required]
		public List<Bookings> Bookings{get;set;} = new List<Bookings>();
	}
}
