
using Notes.Identity;
using Notes.Identity.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<AuthDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception e)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error occurred while app initialize");
            }
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder.UseStartup<Startup>());
    }
}