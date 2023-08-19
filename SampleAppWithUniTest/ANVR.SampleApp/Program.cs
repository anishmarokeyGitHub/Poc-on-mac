
using ANVR.SampleApp;
using ANVR.SampleApp.Business;
using ANVR.SampleApp.Models;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = Startup.ConfigureServices();
var businessManager = serviceProvider.GetService<IBusinessManager>();
await businessManager.AddStudent(1, new Student { Id = 1, Name = "Anish", Age = 32 });
var fristStudent = await businessManager.GetStudentAsync(1);

Console.WriteLine("Hello, World!");
