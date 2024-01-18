namespace SqlExamples.Models;

public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }

    // Foreign key
    public int DepartmentId { get; set; }

    // Navigation property
    public virtual Department Department { get; set; }
}
