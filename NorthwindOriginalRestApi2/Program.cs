using Microsoft.EntityFrameworkCore;
using NorthwindOriginalRestApi2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injektio v‰litetty tietokantatieto kontrollereille
builder.Services.AddDbContext<NorthwindOriginalContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("paikallinen")
    //builder.Configuration.GetConnectionString("pilvi")
    ));



//---- Cors M‰‰ritys---- Ulkopuolisen sovelluksen yhteyden ottaa vaan cors m‰‰ritellyn avulla. 
//-- Oletus ilman Cors m‰‰rityst‰ ei saa yhteytt‰ sovellukseen 
builder.Services.AddCors(options =>
{
    options.AddPolicy("all",
    builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//-- ottaa kaikki yhteyden cors m‰‰ritys avulla 
app.UseCors("all");

app.UseAuthorization();

app.MapControllers();

app.Run();
