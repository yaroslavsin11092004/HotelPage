using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class RoomsRep
	{
		private HotelDBContext db_context;
		public RoomsRep(HotelDBContext context)
		{
			db_context = context;
		}
		public async Task<int> create_async(Rooms data)
		{
			if (db_context != null && db_context.Rooms != null)
			{
				await db_context.Rooms.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			return -1;
		}
		public async Task<List<Rooms>?> read_all_async()
		{
			if (db_context != null && db_context.Rooms != null)
				return await db_context.Rooms.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(Rooms up_data)
		{
			if (db_context != null && db_context.Rooms != null)
			{
				var data = await db_context.Rooms.FindAsync(up_data.id);
				if (data != null)
				{
					db_context.Entry(data).CurrentValues.SetValues(up_data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
		public async Task<int> delete_async(long id)
		{
			if (db_context != null && db_context.Rooms != null)
			{
				var data = await db_context.Rooms.FindAsync(id);
				if (data != null)
				{
					db_context.Rooms.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
		public async Task<Rooms?> get_numroom_async(decimal numroom)
		{
			if (db_context != null && db_context.Rooms != null)
				return await db_context.Rooms.Where(o => o.Number == numroom).FirstOrDefaultAsync();
			else return null;
		}
		public async Task<Rooms?> get_id_async(long roomid)
		{
			if (db_context != null && db_context.Rooms != null)
				return await db_context.Rooms.FindAsync(roomid);
			else return null;
		}
		public async Task<List<Rooms>?> read_another_room(List<long> roomsid)
		{
			if (db_context != null && db_context.Rooms != null)
				return await db_context.Rooms.Where(o => !roomsid.Contains(o.id)).ToListAsync();
			else return null;
		}
	}
}
