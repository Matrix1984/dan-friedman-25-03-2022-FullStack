using Infrastructure;
using Infrastructure.AcuWeatherHttp;
using Infrastructure.Repositories.CityRepo; 
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

builder.Services.AddScoped<IAcuWeatherHttpService, AcuWeatherHttpService>();
 
builder.Services
       .AddOptions<AccurateWeatherOptions>()
       .BindConfiguration("AccurateWeather");

var app = builder.Build(); 

app.UseRouting();
  
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
