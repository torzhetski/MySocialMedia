using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.CQRS.Users.Commands.CreateUser;
using SocialMedia.Application.Interfaces;
using SocialMedia.DataBase;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region DbContext Injection
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IDbContext, SocialMediaDbContext>(options => options.UseMySql(connString, ServerVersion.AutoDetect(connString)));
#endregion

#region MediatR Injection
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
});
#endregion

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();