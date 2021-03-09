using StudentAPI.Domain;
using System.Collections.Generic;

namespace StudentAPI.Repositories
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        IEnumerable<Student> GetAll();
    }
}
