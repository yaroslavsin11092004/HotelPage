using System.ComponentModel.DataAnnotations;
namespace Dto 
{
	public class GuestsInputDto
	{
		public long id{get;set;}
		public required string Name{get;set;}
		public required string Surname{get;set;}
		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Format email: XXXX@XXXX.XX")]
		public required string Email{get;set;}
		[RegularExpression(@"^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$", ErrorMessage = "Format of phone: +X(XXX)XXX-XX-XX")]
		public required string Phone{get;set;}
	}
	public class GuestsOutputDto
	{
		public required long id{get;set;}
		public required string Name{get;set;}
		public required string Surname{get;set;}
		public required string Phone{get;set;}
		public required string Email{get;set;}
	}
}
