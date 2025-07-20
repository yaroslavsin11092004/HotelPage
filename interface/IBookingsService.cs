using Dto;
namespace Service
{
	public interface IBookingsService
	{
		public Task<List<RoomsDto>> read_free_number_async(BookingsDto data);
		public Task<List<BookingsDto>> read_bookings_name_sname_async(string name, string surname);
		public Task create_async(BookingsDto data);
		public Task<List<BookingsDto>> read_all_async();
		public Task update_async(BookingsDto data);
		public Task delete_async(long id);
	}
}
