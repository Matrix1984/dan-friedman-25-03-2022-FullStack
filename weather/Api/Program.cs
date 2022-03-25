using Infrastructure;
using Infrastructure.Repositories.CityRepo;
using Infrastructure.Repositories.FavouriteRepo;
using Infrastructure.Repositories.WeatherRepo;
using Infrastructure.UnitOfWorks.CityUoW;
using Microsoft.EntityFrameworkCore;
using Models.AppSettingsDTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
 
builder.Services.AddDbContext<WeatherDbContext>(opt =>
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: options =>
    {
        options.MigrationsAssembly("Api");
    }));

builder.Services.AddHttpClient();

builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();

builder.Services.AddScoped<ICityCreateUoW, CityCreateUoW>(); 

builder.Services
       .AddOptions<AccurateWeatherOptions>()
       .BindConfiguration("AccurateWeather");

var app = builder.Build(); 

app.UseRouting();
  
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
