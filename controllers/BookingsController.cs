using Microsoft.AspNetCore.Mvc;
using Service;
using Dto;
[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
	private readonly IBookingsService service;
	public BookingsController(IBookingsService _service)
	{
		service = _service;
	}
	[HttpGet]
	public async Task<ActionResult<List<BookingsDto>>> get_all_async()
	{
		try
		{
			var bookings = await service.read_all_async();
			return Ok(bookings);
		}
		catch(Exception e)
		{
			return BadRequest(new 
					{
						Error = e.Message
					});
		}
	}
	[HttpPost]
	public async Task<ActionResult> create_async([FromBody] BookingsDto dto)
	{
		try
		{
			await service.create_async(dto);
			return Ok(new { Results = "success"});
		}
		catch(Exception e)
		{
			return BadRequest(new {Error = e.ToString()});
		}
	}
	[HttpPut]
	public async Task<ActionResult> update_async([FromBody] BookingsDto dto)
	{
		try
		{
			await service.update_async(dto);
			return Ok(new {Results = "success"});
		}
		catch(Exception e)
		{
			return BadRequest(new {Error = e.Message});
		}
	}
	[HttpDelete("{id}")]
	public async Task<ActionResult> delete_async(long id)
	{
		try
		{
			await service.delete_async(id);
			return Ok(new { Results = "success"});
		}
		catch(Exception e)
		{
			return BadRequest(new { Error = e.Message });
		}
	}
	[HttpPost("free_rooms")]
	public async Task<ActionResult<List<RoomsDto>>> get_free_room_async([FromBody] BookingsDto dto)
	{
		try
		{
			var rooms = await service.read_free_number_async(dto);
			return Ok(rooms);
		}
		catch(Exception e)
		{
			return BadRequest(new {Error = e.Message});
		}
	}
	[HttpGet("{name}/{surname}")]
	public async Task<ActionResult<List<BookingsDto>>> get_bookings_name_sname_async(string name, string surname)
	{
		try
		{
			var bookings = await service.read_bookings_name_sname_async(name,surname);
			return Ok(bookings);
		}
		catch(Exception e)
		{
			return BadRequest(new {Error = e.Message});
		}
	}
}
