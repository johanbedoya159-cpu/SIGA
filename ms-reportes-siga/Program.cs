<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SIGAPrincipal.BDReportes;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ─────────────────────────────────────────────────────────────
// BASE DE DATOS
// ─────────────────────────────────────────────────────────────
builder.Services.AddDbContext<DataReportes>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("BDReportes")
    )
);

// ─────────────────────────────────────────────────────────────
// JWT
// ─────────────────────────────────────────────────────────────
var jwt = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,

                ValidateAudience = true,

                ValidateLifetime = true,

                ValidateIssuerSigningKey = true,

                ValidIssuer = jwt["Issuer"],

                ValidAudience = jwt["Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            jwt["Key"]!
                        )
                    )
            };
    });

// ─────────────────────────────────────────────────────────────
// AUTORIZACIÓN
// ─────────────────────────────────────────────────────────────
builder.Services.AddAuthorization(options =>
{
    // TODOS AUTENTICADOS
    options.AddPolicy(
        "UsuariosAutenticados",
        policy => policy.RequireAuthenticatedUser()
    );

    // ADMINISTRATIVOS ACADÉMICOS
    options.AddPolicy(
        "AdministrativosAcademicos",
        policy => policy.RequireRole(
            "Admin-Coordinador",
            "Admin-Secretaria",
            "Decano"
        )
    );

    // GESTIÓN GLOBAL
    options.AddPolicy(
        "GestionGlobal",
        policy => policy.RequireRole(
            "Gestion"
        )
    );

    // DOCENTES
    options.AddPolicy(
        "Docentes",
        policy => policy.RequireRole(
            "Docente"
        )
    );

    // ESTUDIANTES Y EGRESADOS
    options.AddPolicy(
        "HistorialAcademico",
        policy => policy.RequireRole(
            "Estudiante",
            "Egresado"
        )
    );
});

// ─────────────────────────────────────────────────────────────
// CONTROLLERS
// ─────────────────────────────────────────────────────────────
builder.Services.AddControllers();

// ─────────────────────────────────────────────────────────────
// SWAGGER
// ─────────────────────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "SIGA - Reportes",
            Version = "v1"
        }
    );

    c.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",

            Type = SecuritySchemeType.Http,

            Scheme = "Bearer",

            BearerFormat = "JWT",

            In = ParameterLocation.Header,

            Description =
                "Ingrese el token JWT así: Bearer {token}"
        }
    );

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
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

                Array.Empty<string>()
            }
        }
    );
});

var app = builder.Build();

// ─────────────────────────────────────────────────────────────
// SWAGGER
// ─────────────────────────────────────────────────────────────
app.UseSwagger();
app.UseSwaggerUI();

// ─────────────────────────────────────────────────────────────
// MIDDLEWARE
// ─────────────────────────────────────────────────────────────
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// ─────────────────────────────────────────────────────────────
// MAP CONTROLLERS
// ─────────────────────────────────────────────────────────────
app.MapControllers();

app.Run();
=======
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
>>>>>>> c80eabf6817f70b31baafaa58ab5833a2c24b543
