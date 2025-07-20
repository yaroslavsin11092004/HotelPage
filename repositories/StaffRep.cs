using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class StaffRep
	{
		private HotelDBContext db_context;
		public StaffRep(HotelDBContext context)
		{
			db_context = context;
		}
		public async Task<int> create_async(Staff data)
		{
			if (db_context != null && db_context.Staff != null)
			{
				await db_context.Staff.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			return -1;
		}
		public async Task<List<Staff>?> read_all_async()
		{
			if (db_context != null && db_context.Staff != null)
				return await db_context.Staff.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(Staff up_data)
		{
			if (db_context != null && db_context.Staff != null)
			{
				var data = await db_context.Staff.FindAsync(up_data.id);
				if (data != null)
				{
					db_context.Entry(data).CurrentValues.SetValues(up_data);
					await db_context.SaveChangesAsync();
				}
				else return -2;
			}
			return -1;
		}
		public async Task<int> delete_async(long id)
		{
			if (db_context != null && db_context.Staff != null)
			{
				var data = await db_context.Staff.FindAsync(id);
				if (data != null)
				{
					db_context.Staff.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
	}
}
