using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class RoomTypesRep
	{
		private HotelDBContext db_context;
		public RoomTypesRep(HotelDBContext context)
		{
			db_context = context;
		}
		public async Task<int> create_async(RoomTypes data)
		{
			if (db_context != null && db_context.RoomTypes != null)
			{
				await db_context.RoomTypes.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			return -1;
		}
		public async Task<List<RoomTypes>?> read_all_async()
		{
			if (db_context != null && db_context.RoomTypes != null)
				return await db_context.RoomTypes.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(RoomTypes up_data)
		{
			if (db_context != null && db_context.RoomTypes != null)
			{
				var data = await db_context.RoomTypes.FindAsync(up_data.id);
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
			if (db_context != null && db_context.RoomTypes != null)
			{
				var data = await db_context.RoomTypes.FindAsync(id);
				if (data != null)
				{
					db_context.RoomTypes.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
	}
}
