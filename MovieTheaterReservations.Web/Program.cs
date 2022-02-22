using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieTheaterReservations.Data.Data;
using MovieTheaterReservations.Services.Services.AuditoriumService;
using MovieTheaterReservations.Services.Services.MovieService;
using MovieTheaterReservations.Services.Services.MovieShowingService;
using MovieTheaterReservations.Services.Services.ReservationService;
using MovieTheaterReservations.Services.Services.SeatService;
using MovieTheaterReservations.Services.Services.TicketService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuditoriumService, AuditoriumService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieShowingService, MovieShowingService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
