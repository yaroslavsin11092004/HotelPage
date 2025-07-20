using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class ServicesRep
	{
		private HotelDBContext db_context;
		public ServicesRep(HotelDBContext context)
		{
			db_context = context;
		}
		public async Task<int> create_async(Services data)
		{
			if (db_context != null && db_context.Services != null)
			{
				await db_context.Services.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			return -1;
		}
		public async Task<List<Services>?> read_all_async()
		{
			if (db_context != null && db_context.Services != null)
				return await db_context.Services.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(Services up_data)
		{
			if (db_context != null && db_context.Services != null)
			{
				var data = await db_context.Services.FindAsync(up_data.id);
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
			if (db_context != null && db_context.Services != null)
			{
				var data = await db_context.Services.FindAsync(id);
				if (data != null)
				{
					db_context.Services.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
	}
}
