using ANVR.SampleApp.Repository.Data;

namespace ANVR.SampleApp.Models;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
public class Student : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Name { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public int Age { get; set; }
}