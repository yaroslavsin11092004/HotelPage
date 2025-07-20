using Repositories;
using Service;
namespace Hotel
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<HotelDBContext>();
			builder.Services.AddScoped<GuestsRep>();
			builder.Services.AddScoped<BookingsRep>();
			builder.Services.AddScoped<BookedServicesRep>();
			builder.Services.AddScoped<PaymentsRep>();
			builder.Services.AddScoped<RoomAssignmentsRep>();
			builder.Services.AddScoped<RoomsRep>();
			builder.Services.AddScoped<RoomTypesRep>();
			builder.Services.AddScoped<ServicesRep>();
			builder.Services.AddScoped<StaffRep>();

			builder.Services.AddScoped<IGuestsService, GuestsService>();
			builder.Services.AddScoped<IBookingsService, BookingsService>();

			builder.Services.AddControllers();
			builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Разрешить все домены (для разработки)
              .AllowAnyMethod()  // Разрешить все HTTP-методы
              .AllowAnyHeader(); // Разрешить все заголовки
    });
});

			var app = builder.Build();
			app.UseCors("AllowAll");
			app.MapControllers();
			app.Run();
		}
	}
}
