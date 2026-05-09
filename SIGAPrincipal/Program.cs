using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SIGAPrincipal;

// 🔹 DbContext
using SIGAPrincipal.BDAcademico;
using SIGAPrincipal.BDAdministrativa;
using SIGAPrincipal.BDAutenticacion;
using SIGAPrincipal.BDNotificacion;
using SIGAPrincipal.BDReportes;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔥 DbContext (cada uno con su propia BD)
builder.Services.AddDbContext<DataAcademico>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BDAcademico")));

builder.Services.AddDbContext<DataAutenticacion>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BDAutenticacion")));

builder.Services.AddDbContext<DataAdministrativa>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BDAdministrativa")));

builder.Services.AddDbContext<DataNotificacion>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BDNotificacion")));

builder.Services.AddDbContext<DataReportes>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BDReportes")));


// 🔥 JWT CONFIG
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; 

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

// 🔥 Servicio JWT
builder.Services.AddScoped<JwtService>();


// 🔥 Controllers + Swagger
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SIGA", Version = "v1" });

    // 🔐 JWT en Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Escribe: Bearer {tu token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();


// 🔥 Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllers();

app.Run();
