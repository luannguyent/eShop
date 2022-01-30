using Catalog.API.Models;
using Catalog.Domain.CatalogAggregate;
using Catalog.Domain.SeedWork;
using Catalog.Infrastructure;
using Catalog.Infrastructure.DataContext;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICatalogBrandRepository, CatalogBrandRepository>();
builder.Services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
builder.Services.AddTransient<ICatalogTypeRepository, CatalogTypeRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.Configure<CatalogSettings>(builder.Configuration.GetSection("Settings"));
builder.Services.AddDbContext<CatalogDbContext>(options => {
    options.UseSqlServer(connString);
});

var audienceConfig = builder.Configuration.GetSection("Audience");

var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = signingKey,
    ValidateIssuer = true,
    ValidIssuer = audienceConfig["Iss"],
    ValidateAudience = true,
    ValidAudience = audienceConfig["Aud"],
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero,
    RequireExpirationTime = true,
};

builder.Services.AddAuthentication().AddJwtBearer("eShop.JWT", jwt => {
    jwt.RequireHttpsMetadata = false;
    jwt.TokenValidationParameters = tokenValidationParameters;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
    });
}

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), @"Pics")),
    RequestPath = new PathString("/app-images")
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
