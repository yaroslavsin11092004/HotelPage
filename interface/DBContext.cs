using Microsoft.EntityFrameworkCore;
using Models;
namespace Hotel
{
	public class HotelDBContext : DbContext
	{
		public DbSet<Guests>? Guests{get;set;}
		public DbSet<Bookings>? Bookings{get;set;}
		public DbSet<BookedServices>? BookedServices{get;set;}
		public DbSet<Payments>? Payments{get;set;}
		public DbSet<RoomAssignments>? RoomAssignments{get;set;}
		public DbSet<Rooms>? Rooms{get;set;}
		public DbSet<RoomTypes>? RoomTypes{get;set;}
		public DbSet<Services>? Services{get;set;}
		public DbSet<Staff>? Staff{get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    	{
			  string connect = "Host=localhost;Username=postgres;Password=Ss04121983#;Database=HotelDB";
      	optionsBuilder.UseNpgsql(connect);
      }
  }
}
