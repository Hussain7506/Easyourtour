using Easyourtour.Data;
using Easyourtour.Repository;
using Easyourtour.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDestination, DestinationRepository>();
builder.Services.AddScoped<ILocation, LocationRepository>();
builder.Services.AddScoped<ILocationImage, LocationImageRepository>();
builder.Services.AddScoped<IHotel, HotelRepository>();
builder.Services.AddScoped<IHotelImage, HotelImageRepository>();
builder.Services.AddScoped<IHotelRoom, HotelRoomRepository>();
builder.Services.AddScoped<IHotelRoomImage, HotelRoomImageRespository>();
builder.Services.AddScoped<ITransport, TransportRepository>();
builder.Services.AddScoped<ISightseeing, SightseeingRepository>();
builder.Services.AddScoped<ISightseeingImage, SightseeingImageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
