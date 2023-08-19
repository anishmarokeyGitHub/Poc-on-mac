using ANVR.SampleApp.Repository;

namespace ANVR.SampleApp.Business.Students;

internal sealed class StudentBusinesManager : IStudentBusinessManager
{
    private readonly IRepository<Student> _repository;

    #region Constructor
    public StudentBusinesManager(IRepository<Student> repository)
    {
        _repository = repository;
    }
    #endregion

    #region IBusinessManager Implementation

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Student> GetStudentAsync(int id)
    {
        var student = await _repository.Get(id);
        return student;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="student"></param>
    /// <returns></returns>
    public async Task<bool> AddStudent(int id, Student student)
    {
        await _repository.Set(id, student);
        return true;
    }
    #endregion
}
