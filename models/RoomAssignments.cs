using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Models
{
	[Table("RoomAssignments", Schema = "Essence")]
	public class RoomAssignments
	{
		[Column("Date")]
		public DateTimeOffset Date{get;set;}
		[Column("RoomId")][ForeignKey("Rooms")]
		public long RoomId{get;set;}
		[Required]
		public Rooms Rooms{get;set;} = new Rooms();
		[Column("StaffId")][ForeignKey("Staff")]
		public long StaffId{get;set;}
		[Required]
		public Staff Staff{get;set;} = new Staff();
		[Column("id")][Key]
		public long id{get;set;}
	}
}
