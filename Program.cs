using simple.Data;
using Microsoft.EntityFrameworkCore;
using simple;
using System.Text.Json;
using Microsoft.Identity.Client.Kerberos;
using static System.Formats.Asn1.AsnWriter;
using simple.Interfaces;
using simple.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRecipeRepo, RecipeRepository>();
builder.Services.AddDbContext<IDataContext,DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

