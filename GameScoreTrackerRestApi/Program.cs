using DatabaseConnection;
using GameScoreTrackerRestApi;
using Interfaces;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

const bool useDataBase = true;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<GameScoreManager, GameScoreManager>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//for prod, using environment variable:
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//                               ?? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

if (useDataBase)
{
    builder.Services.AddScoped<IDataBaseWrapper, DataBaseWrapper>();
    builder.Services.AddDbContext<GameScoreDatabaseContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    builder.Services.AddScoped<IDataBaseWrapper, PlaceHolderDataBaseWrapper>();
}


    var app = builder.Build();

//To migrate on startup:
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<GameScoreDatabaseContext>();
//    dbContext.Database.Migrate();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();   //UseRouting, UseEndpoints


//Convention based routing:
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=GameScoreTracker}/{action=Games}/{id}");  


//app.MapControllerRoute(name: "API Default",
//    routeTemplate: "api/{controller}/{id}");

app.Run();



