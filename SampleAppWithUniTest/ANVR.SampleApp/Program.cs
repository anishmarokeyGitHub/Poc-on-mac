
using System.Diagnostics.CodeAnalysis;
using ANVR.SampleApp;
using ANVR.SampleApp.Business.Students;
using ANVR.SampleApp.Business.Teacher;
using Microsoft.Extensions.DependencyInjection;
 [ExcludeFromCodeCoverage]
internal class Program
{
    private static async Task Main(string[] args)
    {
       
        var serviceProvider = Startup.ConfigureServices();
        var businesStudentManager = serviceProvider.GetService<IStudentBusinessManager>();
        await businesStudentManager.AddStudent(1, new Student { Id = 1, Name = "Anish", Age = 32 });
        var fristStudent = await businesStudentManager.GetStudentAsync(1);


        var businesTeacherManager = serviceProvider.GetService<ITeacherBusinessManager>();
        await businesTeacherManager.AddTeacher(1, new Teacher { Id = 1, Department = "CSE" });
        var fristTeacher = await businesTeacherManager.GetTeacherAsync(1);

        Console.WriteLine("Hello, World!");
    }
}