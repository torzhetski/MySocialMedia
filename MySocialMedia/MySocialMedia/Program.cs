using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Application;
using SocialMedia.Application.CQRS.Users.Commands.RegisterUser;
using SocialMedia.Application.Interfaces;
using SocialMedia.DataBase;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region DbContext Injection
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IDbContext, SocialMediaDbContext>(options => options.UseMySql(connString, ServerVersion.AutoDetect(connString)));
#endregion

#region MediatR Injection
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly);
});
#endregion

#region Authentication && Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                   .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                                   {
                                       options.TokenValidationParameters = new()
                                       {
                                           ValidateIssuer = false,
                                           ValidateAudience = false,
                                           ValidateLifetime = true,
                                           ValidateIssuerSigningKey = true,
                                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWTOptions:SecretKey")))
                                       };
                                   });
builder.Services.AddAuthorization();
#endregion

builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();