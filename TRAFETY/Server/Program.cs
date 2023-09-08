using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;
using TRAFETY.Bd.Contexto;
using TRAFETY.Bd.Usuario;
using TRAFETY.Server.Repositorios;
using TRAFETY.Server.Repositorios.Personas;
using TRAFETY.Server.Mapeo;
using TRAFETY.Server.Repositorios.TTipo;

var builder = WebApplication.CreateBuilder(args);
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

#region SERVICES

var conn = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<Context>(
    opciones => opciones.UseSqlServer(conn,
    sqlServerOptions => sqlServerOptions.UseNetTopologySuite()
    )
);

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opciones => opciones.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(builder.Configuration["jwtkey:llave"]!)),
        ClockSkew = TimeSpan.Zero
    });

builder.Services.AddAuthorization(opciones =>
{
    opciones.AddPolicy("Anónimo", politica => politica.RequireClaim("Anonimo"));
    opciones.AddPolicy("Participante", politica => politica.RequireClaim("Participante"));
    opciones.AddPolicy("Organizador", politica => politica.RequireClaim("Organizador"));
    opciones.AddPolicy("Guia", politica => politica.RequireClaim("Guia"));
    opciones.AddPolicy("Admin", politica => politica.RequireClaim("Admin"));
});

builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "TRAFETY", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Please enter token"
        }
        );
        //Type = SecuritySchemeType.ApiKey,

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new string[]{}
                 }
            }
        );
    }
);

//MAPPER + GEOMETRIA
builder.Services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));
builder.Services.AddSingleton(provider =>
    new MapperConfiguration(config =>
    {
        var geometryFactory = provider.GetRequiredService<GeometryFactory>();
        config.AddProfile(new AutoMapperProfile(geometryFactory));
    }).CreateMapper()
);

#region INJECTION SERVICES
#region CONTEXTO
builder.Services.AddScoped<IRepositorio<IEntidadBase>, Repositorio<IEntidadBase>>();
#endregion

#region EMPRESAS
#endregion

#region PERSONAS
builder.Services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddScoped<IGuiaRepositorio, GuiaRepositorio>();
#endregion

#region SALIDAS
#endregion

#region TTIPO
builder.Services.AddScoped<ITContactoRepositorio, TContactoRepositorio>();
builder.Services.AddScoped<ITEmpresaRepositorio, TEmpresaRepositorio>();
builder.Services.AddScoped<ITGuiaRepositorio, TGuiaRepositorio>();
builder.Services.AddScoped<ITOrganizacionRepositorio, TOrganizacionRepositorio>();
builder.Services.AddScoped<ITStaffRepositorio, TStaffRepositorio>();
#endregion

#region USUARIO
#endregion

#endregion

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#endregion

var app = builder.Build();

#region MIDDLEWARE

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TRAFETY v1"));

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

#endregion

app.Run();

//#region ENTIDADES

//#region CONTEXTO
//#endregion

//#region EMPRESAS
//#endregion

//#region PERSONAS
//#endregion

//#region SALIDAS
//#endregion

//#region TTIPO
//#endregion

//#region USUARIO
//#endregion

//#endregion
