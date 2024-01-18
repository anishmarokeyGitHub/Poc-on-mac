using Microsoft.EntityFrameworkCore;
using SqlExamples.Models;

namespace SqlExamples;

public class BusinessClass
{
    private readonly SchoolContext _schoolContext;

    public BusinessClass(SchoolContext schoolContext)
    {
        _schoolContext = schoolContext;
    }
    public void Run()
    {

        // Create a new department
        var department = new Department
        {
            DepartmentId = 1,
            DepartmentName = "Computer Science"
        };

        // Add students to the department
        department.Student = new List<Student>
            {
                new Student { StudentId = 1,  StudentName = "John Doe" , DepartmentId =1 },
                new Student { StudentId =2,  StudentName = "Jane Smith" , DepartmentId =1}
            };

        // Add the department to the context and save changes
        _schoolContext.Department.Add(department);
        _schoolContext.SaveChanges();

        // Retrieve the department with students from the database
        var retrievedDepartment = _schoolContext.Department
            .Include(d => d.Student)
            .FirstOrDefault();

        foreach (var student in retrievedDepartment.Student)
        {
            Console.WriteLine($"- {student.StudentName}");
        }
    }
}