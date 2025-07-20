using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class BookedServicesRep
	{
		private HotelDBContext db_context;
		public BookedServicesRep(HotelDBContext context)
		{
			this.db_context = context;
		}
		public async Task<int> create_async(BookedServices data)
		{
			if (db_context != null && db_context.BookedServices != null)
			{
				await db_context.BookedServices.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			else return -1;
		}
		public async Task<List<BookedServices>?> read_all_async()
		{
			if (db_context != null && db_context.BookedServices != null)
				return await db_context.BookedServices.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(BookedServices up_data)
		{
			if (db_context != null && db_context.BookedServices != null)
			{
				var data = await db_context.BookedServices.FindAsync(up_data.id);
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
			if (db_context != null && db_context.BookedServices != null)
			{
				var data = await db_context.BookedServices.FindAsync();
				if (data != null)
				{
					db_context.BookedServices.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
	}
}

