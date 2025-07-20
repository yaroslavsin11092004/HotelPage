using Microsoft.AspNetCore.Mvc;
using Service;
using Dto;
[ApiController]
[Route("api/guests")]
[Produces("application/json")]
public class GuestsController : ControllerBase
{
	private readonly IGuestsService service;
	public GuestsController(IGuestsService _service)
	{
		service = _service;
	}
	[HttpGet]
	public async Task<ActionResult<List<GuestsOutputDto>>> get_all()
	{
		try
		{
			var guests = await service.read_all_async();
			return Ok(guests);
		}
		catch(Exception e)
		{
			return BadRequest(new 
					{ Error = e.Message
				});
		}
	}
	[HttpPost]
	public async Task<ActionResult> create([FromBody] GuestsInputDto dto)
	{
		if (!ModelState.IsValid)
			return BadRequest();
		try
		{
			await service.create_async(dto);
			return Ok();
		}
		catch(Exception e)
		{
			return BadRequest(new {
				 Error =  e.Message
				});
		}
	}
	[HttpPut]
	public async Task<ActionResult> update([FromBody] GuestsInputDto dto)
	{
		if (!ModelState.IsValid)
			return BadRequest();
		try
		{
			await service.update_async(dto);
			return Ok();
		}
		catch(Exception e)
		{
			return BadRequest(new {
					Error = e.Message
					});
		}
	}
	[HttpDelete("{id}")]
	public async Task<ActionResult> delete(long id)
	{
		try
		{
			await service.delete_async(id);
			return Ok();
		}
		catch(Exception e)
		{
			return BadRequest(new {
					Error = e.ToString()
					});
		}
	}
}
