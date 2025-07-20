using Dto;
using Repositories;
using Models;
namespace Service
{
	public class GuestsService : IGuestsService
	{
		private readonly GuestsRep rep;
		public GuestsService(GuestsRep repos)
		{
			rep = repos;
		}
		public async Task create_async(GuestsInputDto data)
		{
			var guest = new Guests
			{
				Name = data.Name,
				Surname = data.Surname,
				Phone = data.Phone,
				Email = data.Email,
				RegData = DateTimeOffset.Now.ToUniversalTime()
			};
			int code = await rep.create_async(guest);
			if (code == -1)
				throw new Exception("Error of connecting database");
		}
		public async Task<List<GuestsOutputDto>> read_all_async()
		{
			var guests = await rep.read_all_async();
			List<GuestsOutputDto> ret_value = new List<GuestsOutputDto>();
			if (guests != null)
			{
				foreach(var i in guests)
					ret_value.Add(new GuestsOutputDto
					{
						Name = i.Name,
						id = i.id,
						Surname = i.Surname,
						Phone = i.Phone,
						Email = i.Email
					});
			}
			return ret_value;
		}
		public async Task update_async(GuestsInputDto data)
		{
			var up_data = new Guests
			{
				Name = data.Name,
				Surname = data.Surname,
				Email = data.Email,
				id = data.id,
				Phone = data.Phone,
				RegData = DateTimeOffset.Now.ToUniversalTime()
			};
			int code = await rep.update_async(up_data);
			if (code == -1)
				throw new Exception("Error of connecting database");
			else if (code == -2)
				throw new Exception("This data not exsist");
		}
		public async Task delete_async(long id)
		{
			int code = await rep.delete_async(id);
			if (code == -1)
				throw new Exception("Error of connecting database");
			else if (code == -2)
				throw new Exception($"This data not exsist - id = {id}");
		}
	}
}
