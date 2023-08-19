namespace ANVR.SampleApp.Business.Students;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
public interface IStudentBusinessManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns> <summary> 
    public Task<Student> GetStudentAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="student"></param>
    /// <returns></returns>
    public Task<bool> AddStudent(int id, Student student);
}
