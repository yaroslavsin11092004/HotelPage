using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class PaymentsRep
	{
		private HotelDBContext db_context;
		public PaymentsRep(HotelDBContext context)
		{
			this.db_context = context;
		}
		public async Task<int> create_async(Payments data)
		{
			if (db_context != null && db_context.Payments != null)
			{
				await db_context.Payments.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			else return -1;
		}
		public async Task<List<Payments>?> read_all_async()
		{
			if (db_context != null && db_context.Payments != null)
				return await db_context.Payments.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(Payments up_data)
		{
			if (db_context != null && db_context.Payments != null)
			{
				var data = await db_context.Payments.FindAsync(up_data.id);
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
			if (db_context != null && db_context.Payments != null)
			{
				var data = await db_context.Payments.FindAsync(id);
				if (data != null)
				{
					db_context.Payments.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
	}
}


