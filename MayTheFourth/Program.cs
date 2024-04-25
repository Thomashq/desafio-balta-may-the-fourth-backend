using MayTheFourth;
using MayTheFourth.Data;
using MayTheFourth.Routes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCors(options =>
    options.AddPolicy(
        Configuration.CorsPolicyName,
        policy =>
            policy.WithOrigins([
                Configuration.BackendUrl,
                Configuration.FrontendUrl
            ])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        )
);

var app = builder.Build();

app.UseCors(Configuration.CorsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapStarShipRoutes();
app.MapCharacterRoutes();
app.MapPlanetRoutes();

app.UseHttpsRedirection();

app.Run();