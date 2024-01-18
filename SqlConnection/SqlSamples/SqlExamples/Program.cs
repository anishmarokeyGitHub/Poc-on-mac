using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SqlExamples;

class Program
{
    static void Main()
    {
        // var sqlConfig = "Server=tcp:primary-care-dev.database.windows.net,1433;Initial Catalog=primary-care-dev;Persist Security Info=False;User ID=mainstreet;Password=M@1nstreet17;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        var sqlConfig = "Server=localhost,1433;Initial Catalog=sampledb;Persist Security Info=False;User ID=sa;Password=VeryStr0ngP@ssw0rd;TrustServerCertificate=True;";
        var services = new ServiceCollection();
        services.AddTransient(p => new SqlHealthChecker(sqlConfig));
        services.AddTransient<BusinessClass>();
        services.AddDbContext<SchoolContext>(options =>
                    options.UseSqlServer(sqlConfig));
        var serviceProvider = services.BuildServiceProvider();

        var businessClass = serviceProvider.GetService<BusinessClass>();

        businessClass.Run();
        Console.WriteLine("Exited Code");

    }
}
