using Dto;
using Models;
using Repositories;
namespace Service
{
	public class BookingsService : IBookingsService
	{
		private readonly GuestsRep guests_rep;
		private readonly BookingsRep bookings_rep;
		private readonly RoomsRep rooms_rep;
		public BookingsService(GuestsRep _guests_rep, BookingsRep _bookings_rep, RoomsRep _rooms_rep)
		{
			this.guests_rep = _guests_rep;
			this.bookings_rep = _bookings_rep;
			this.rooms_rep = _rooms_rep;
		}
		public async Task create_async(BookingsDto data)
		{
			var guest = await guests_rep.read_name_sname_guest_async(data.Name, data.Surname);
			var room = await rooms_rep.get_numroom_async(data.NumberRoom);
			string error = "";
			if (guest == null)
				error += "Guest not found!\n";
			if (room == null)
				error += "Room not found!\n";
			if (error != "")
				throw new Exception(error);
			Bookings booking = new Bookings
			{
				GuestId = guest.id,
				Guest = guest,
				Rooms= room,
				RoomId = room.id,
				Status = "подтверждено",
				DateArrived = data.DateArrived.ToUniversalTime(),
				DateDeparture = data.DateDeparture.ToUniversalTime()
			};
			int code = await bookings_rep.create_async(booking);
			if (code == -1)
				throw new Exception("Error of connecting database");
		}
		public async Task<List<BookingsDto>> read_all_async()
		{
			List<BookingsDto> res = new List<BookingsDto>();
			var bookings = await bookings_rep.read_all_async();
			foreach (var b in bookings)
			{
				var guest = await guests_rep.read_id_guest_async(b.GuestId);
				var room = await rooms_rep.get_id_async(b.RoomId);
				BookingsDto dto = new BookingsDto
				{
					id = b.id,
					Name = guest.Name,
					Surname = guest.Surname,
					NumberRoom = room.Number,
					Status = b.Status,
					DateDeparture = b.DateDeparture.ToUniversalTime(),
					DateArrived = b.DateArrived.ToUniversalTime()
				};
				res.Add(dto);
			}
			return res;
		}
		public async Task update_async(BookingsDto data)
		{
			var guest = await guests_rep.read_name_sname_guest_async(data.Name, data.Surname);
			var room = await rooms_rep.get_numroom_async(data.NumberRoom);
			if (guest != null)
			{
				if (room != null)
				{
					var last_version = await bookings_rep.get_guestid_roomid_async(guest.id, room.id);
					if (last_version != null)
					{
						Bookings up_data = new Bookings
						{
							Status = data.Status,
							RoomId = room.id,
							GuestId = guest.id,
							Rooms = room,
							Guest = guest,
							DateArrived = last_version.DateArrived.ToUniversalTime(),
							DateDeparture = last_version.DateDeparture.ToUniversalTime(),
							id = last_version.id
						};
						await bookings_rep.update_async(up_data);
					}
					else throw new Exception("Data not found!");
				}
				else throw new Exception("Room not found!");
			}
			else throw new Exception("Guest not found!");
		}
		public async Task delete_async(long id)
		{
			await bookings_rep.delete_async(id);
		}
		public async Task<List<BookingsDto>> read_bookings_name_sname_async(string name, string surname)
		{
			List<BookingsDto> res = new List<BookingsDto>();
			var guest = await guests_rep.read_name_sname_guest_async(name, surname);
			if (guest != null)
			{
				var bookings = await bookings_rep.get_guestid_async(guest.id);
				if (bookings != null)
				{
					foreach (var b in bookings)
					{
						var room = await rooms_rep.get_id_async(b.RoomId);
						if (room != null)
						{
							var dto = new BookingsDto
							{
								Name = guest.Name,
								Surname = guest.Surname,
								NumberRoom = room.Number,
								id = b.id,
								DateArrived = b.DateArrived.ToUniversalTime(),
								DateDeparture = b.DateDeparture.ToUniversalTime(),
								Status = b.Status
							};
							res.Add(dto);
						}
					}
					return res;
				}
				else throw new Exception("Bookings not found!");
			}
			else throw new Exception("Guest not found!");
		}
		public async Task<List<RoomsDto>> read_free_number_async(BookingsDto data)
		{
			var busy = await bookings_rep.read_range_bookings(data.DateArrived.ToUniversalTime(), data.DateDeparture.ToUniversalTime());
			if (busy != null)
			{
				List<long> bid = new List<long>();
				foreach(var b in busy)
					bid.Add(b.RoomId);
				var free_rooms = await rooms_rep.read_another_room(bid);
				if (free_rooms != null)
				{
					List<RoomsDto> res = new List<RoomsDto>();
					foreach(var fr in free_rooms)
					{
						RoomsDto dto = new RoomsDto
						{
							id = fr.id,
							Number = fr.Number,
							Type = fr.Type,
							CostPerNight = fr.CostPerNight,
							Capacity = fr.Capacity
						};
						res.Add(dto);
					}
					return res;
				}
				else throw new Exception("Don't exist free room!");
			}
			else throw new Exception("All room is free!");
		}
	}
}
