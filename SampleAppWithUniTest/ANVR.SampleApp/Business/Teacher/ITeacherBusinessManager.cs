namespace ANVR.SampleApp.Business.Teacher;

public interface ITeacherBusinessManager
{
     /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns> <summary> 
    public Task<Teacher> GetTeacherAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="student"></param>
    /// <returns></returns>
    public Task<bool> AddTeacher(int id, Teacher student);
}
