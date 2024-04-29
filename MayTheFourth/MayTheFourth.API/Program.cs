using MayTheFourth;
using MayTheFourth.Data;
using MayTheFourth.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("DataSource=../MayTheFourth.Infrastructure/app.db;Cache=Shared");
});

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

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<AppDbContext>();
db?.Database.MigrateAsync();

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
app.MapMovieRoutes();
app.MapVehicleRoutes();

app.UseHttpsRedirection();

app.Run();

public partial class Program { }