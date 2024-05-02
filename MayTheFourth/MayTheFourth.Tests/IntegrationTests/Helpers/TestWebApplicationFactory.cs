using MayTheFourth.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MayTheFourth.Tests.IntegrationTests.Helpers;
public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

            if(descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                options.UseSqlite($"Data Source={Path.Join(path, "app_tests.db")}");
            });
        });
        return base.CreateHost(builder);
    }
}
