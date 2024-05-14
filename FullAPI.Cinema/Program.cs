using FullAPI.Cinema.Data;
using FullAPI.Cinema.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connString = builder.Configuration.GetConnectionString("Default")!;
builder.Services.AddSqlServer<CinemaDbContext>(connString);
builder.Services.AddSingleton<Mapper>();

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(o =>
{
    o.AddPolicy(MyAllowSpecificOrigins, b =>
    {
        //b.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader();
        b.AllowAnyOrigin();
        b.AllowAnyMethod();
        b.AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetService<CinemaDbContext>();
    ctx.Database.Migrate();

    if(!ctx.Technologies.Any())
    {
        string json = File.ReadAllText("technologies.json");
        List<TechnologyJson>? technologies = JsonSerializer.Deserialize<List<TechnologyJson>>(json);
    }
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();