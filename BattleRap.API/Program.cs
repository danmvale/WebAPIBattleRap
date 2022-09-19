using BattleRap.API.Context;
using BattleRap.API.Repositories;
using BattleRap.API.Repositories.Interfaces;
using BattleRap.API.Auth.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using BattleRap.API.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(cors => cors.AddPolicy("AllowOriginAndMethod", options => options
                .WithOrigins("https://localhost")
                .WithMethods("*")));

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Informe o token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }

    });
});

var connectionString = "";

if (builder.Environment.IsDevelopment())
    connectionString = builder.Configuration["DefaultConnection"];
else if (builder.Environment.IsProduction())
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<UserRepository>();

#region Authentication and Authorization Settings

var tokenConfiguration = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(builder.Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
builder.Services.AddSingleton(tokenConfiguration);
var generateToken = new GenerateToken(tokenConfiguration);
builder.Services.AddScoped(typeof(GenerateToken));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ClockSkew = TimeSpan.Zero,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidAudience = tokenConfiguration.Audience,
        ValidIssuer = tokenConfiguration.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
    };
});

builder.Services.AddAuthorization(options => options.AddPolicy("ValidateClaimModule", policy => policy.RequireClaim("module", "Web III .net")));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOriginAndMethod");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
