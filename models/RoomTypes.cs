using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Models
{
	[Table("RoomTypes", Schema = "Essence")]
	public class RoomTypes
	{
		[Column("id")][Key]
		public long id{get;set;}
		[Column("Title")]
		public string? Title{get;set;}
		[Column("Description")]
		public string? Description{get;set;}
	}
}
