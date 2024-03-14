using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prospectos;
using Prospectos.Data;
using Prospectos.Data.Interfaces;
using Prospectos.Services;
using Prospectos.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();
builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddSingleton(jwtOptions);

// Configuring the Authentication Service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token"])),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

// Configuring the Authorization Service
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IApiRepository, ApiRepository>();
builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseLazyLoadingProxies();
    x.UseSqlite(builder.Configuration["DefaultConnection"]);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEnd", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors("FrontEnd");
app.Run();
