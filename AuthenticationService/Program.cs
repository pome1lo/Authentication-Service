using AuthenticationService.Database;
using AuthenticationService.Services;
using JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Database context Dependency Injection  
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var conntectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPass};TrustServerCertificate=true;";
builder.Services.AddDbContext<AccountDbContext>(opt => opt.UseSqlServer(conntectionString));

builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddScoped<AccountService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();