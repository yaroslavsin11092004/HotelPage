using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class RoomAssignmentsRep
	{
		private HotelDBContext db_context;
		public RoomAssignmentsRep(HotelDBContext context)
		{
			db_context = context;
		}
		public async Task<int> create_async(RoomAssignments data)
		{
			if (db_context != null && db_context.RoomAssignments != null)
			{
				await db_context.RoomAssignments.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			return -1;
		}
		public async Task<List<RoomAssignments>?> read_all_async()
		{
			if (db_context != null && db_context.RoomAssignments != null)
				return await db_context.RoomAssignments.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(RoomAssignments up_data)
		{
			if (db_context != null && db_context.RoomAssignments != null)
			{
				var data = await db_context.RoomAssignments.FindAsync(up_data.id);
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
			if (db_context != null && db_context.RoomAssignments != null)
			{
				var data = await db_context.RoomAssignments.FindAsync(id);
				if (data != null)
				{
					db_context.RoomAssignments.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
	}
}
