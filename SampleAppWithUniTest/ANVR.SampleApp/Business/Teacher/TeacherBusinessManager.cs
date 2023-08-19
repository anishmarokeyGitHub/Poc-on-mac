using ANVR.SampleApp.Repository;

namespace ANVR.SampleApp.Business.Teacher;

public class TeacherBusinessManager : ITeacherBusinessManager
{

    private readonly IRepository<Teacher> _repository;

    #region Constructor
    public TeacherBusinessManager(IRepository<Teacher> repository)
    {
        _repository = repository;
    }
    #endregion

    #region IBusinessManager Implementation

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="student"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception> <summary>
    public async Task<bool> AddTeacher(int id, Teacher student)
    {
        await _repository.Set(id, student);
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception> <summary> 
    public async Task<Teacher> GetTeacherAsync(int id)
    {
        return await _repository.Get(id); 
    }
    #endregion
}
