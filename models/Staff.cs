using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Models
{
	[Table("Staff", Schema = "Essence")]
	public class Staff
	{
		[Column("id")][Key]
		public long id{get;set;}
		[Column("Name")]
		public string? Name{get;set;}
		[Column("Surname")]
		public string? Surname{get;set;}
		[Column("Position")]
		public string? Position{get;set;}
		[Required]
		public List<Rooms> Rooms{get;set;} = new List<Rooms>();
	}
}
