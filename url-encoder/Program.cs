
using Microsoft.EntityFrameworkCore;
using url_encoder.Database;
using url_encoder.Url;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer
    (
        builder.Configuration.GetConnectionString("DefaultConnection"))
    ); ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
