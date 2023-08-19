using ANVR.SampleApp.Models;
using ANVR.SampleApp.Repository;

namespace ANVR.SampleApp.Business;

internal sealed class BusinessManager : IBusinessManager
{
    private readonly IRepository _repository;

    #region Constructor
    public BusinessManager(IRepository repository)
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
        return (Student)student;
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
