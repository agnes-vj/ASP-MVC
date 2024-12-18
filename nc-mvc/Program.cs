using nc_mvc.Models;
using nc_mvc.Services;

namespace nc_mvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddScoped<AuthorsService>();
        builder.Services.AddScoped<AuthorsModel>();

        var app = builder.Build();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapControllers();
        });

        app.Run();
    }
}
