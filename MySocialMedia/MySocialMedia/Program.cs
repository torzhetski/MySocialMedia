using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Interfaces;
using SocialMedia.Core.Models;
using SocialMedia.DataBase;

var builder = WebApplication.CreateBuilder(args);

#region DbContext Injection
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IDbContext, SocialMediaDbContext>(options => options.UseMySql(connString, ServerVersion.AutoDetect(connString)));
#endregion

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
