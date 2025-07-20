using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class GuestsRep
	{
		private HotelDBContext db_context;
		public GuestsRep(HotelDBContext context) 
		{ 
			this.db_context = context; 
		}
		public async Task<List<Guests>?> read_all_async()
		{
			if (db_context != null && db_context.Guests != null)
				return await db_context.Guests.ToListAsync();
			else 
					return null;
		}
		public async Task<int> create_async(Guests data)
		{
			if (db_context != null && db_context.Guests != null)
			{
				await db_context.Guests.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			else return -1;
		}
		public async Task<int> update_async(Guests up_data)
		{
			if (db_context != null && db_context.Guests != null)
			{
				var data = await db_context.Guests.FindAsync(up_data.id);
				if (data != null)
				{
					db_context.Entry(data).CurrentValues.SetValues(up_data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else 
					return -2;
			}
			return -1;
		}
		public async Task<int> delete_async(long id)
		{
			if (db_context != null && db_context.Guests != null)
			{
				var data = await db_context.Guests.FindAsync(id);
				if (data != null)
				{
					db_context.Guests.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else 
					return -2;
			}
			return -1;
		}
		public async Task<Guests?> read_name_sname_guest_async(string name, string surname)
		{
			if (db_context != null && db_context.Guests != null)
			{
				return await db_context.Guests.Where(o => o.Name == name && o.Surname == surname).FirstOrDefaultAsync();
			}
			else return null;
		}
		public async Task<Guests?> read_id_guest_async(long guestid)
		{
			if (db_context != null && db_context.Guests != null)
				return await db_context.Guests.FindAsync(guestid);
			else return null;
		}
	}
}
