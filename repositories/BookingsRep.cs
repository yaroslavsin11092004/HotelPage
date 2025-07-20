using Hotel;
using Models;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
	public class BookingsRep
	{
		private HotelDBContext db_context;
		public BookingsRep(HotelDBContext context)
		{
			this.db_context = context;
		}
		public async Task<int> create_async(Bookings data)
		{
			if (db_context != null && db_context.Bookings != null)
			{
				await db_context.Bookings.AddAsync(data);
				await db_context.SaveChangesAsync();
				return 0;
			}
			else return -1;
		}
		public async Task<List<Bookings>?> read_all_async()
		{
			if (db_context != null && db_context.Bookings != null)
				return await db_context.Bookings.ToListAsync();
			else return null;
		}
		public async Task<int> update_async(Bookings up_data)
		{
			if (db_context != null && db_context.Bookings != null)
			{
				var data = await db_context.Bookings.FindAsync(up_data.id);
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
			if (db_context != null && db_context.Bookings != null)
			{
				var data = await db_context.Bookings.FindAsync(id);
				if (data != null)
				{
					db_context.Bookings.Remove(data);
					await db_context.SaveChangesAsync();
					return 0;
				}
				else return -2;
			}
			return -1;
		}
		public async Task<List<Bookings>?> get_guestid_async(long guestid)
		{
			if (db_context != null && db_context.Bookings != null)
				return await db_context.Bookings.Where(o => o.GuestId == guestid).ToListAsync();
			else return null;
		}
		public async Task<Bookings?> get_guestid_roomid_async(long guestid, long roomid)
		{
			if (db_context != null && db_context.Bookings != null)
				return await db_context.Bookings.Where(o => o.GuestId == guestid && o.RoomId == roomid).FirstOrDefaultAsync();
			else return null;
		}
		public async Task<List<Bookings>?> read_range_bookings(DateTimeOffset date_arrived, DateTimeOffset date_departure)
		{
			if (db_context != null && db_context.Bookings != null)
				return await db_context.Bookings.Where(o => (date_departure >= o.DateArrived && date_departure <= o.DateDeparture) || (date_arrived >= o.DateArrived && date_arrived <= o.DateDeparture) || (o.DateArrived >= date_arrived && o.DateDeparture <= date_departure)).ToListAsync();
			else return null;
		}
	}
}
