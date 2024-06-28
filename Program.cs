using simple.Data;
using Microsoft.EntityFrameworkCore;
using simple;
using System.Text.Json;
using static System.Formats.Asn1.AsnWriter;
using simple.Interfaces;
using simple.Respository;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRecipeRepo, RecipeRepository>();
builder.Services.AddDbContext<IDataContext,DataContext>(option =>
{
    var connectionString = builder.Configuration.GetConnectionString("mariadbconnection");
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var provider = serviceScope.ServiceProvider;


app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();

