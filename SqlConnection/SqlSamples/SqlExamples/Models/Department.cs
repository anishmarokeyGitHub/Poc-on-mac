namespace SqlExamples.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }

    // Navigation property
    public virtual ICollection<Student> Student { get; set; }
}
