using CleanArchDemo1.Domain.Models;

namespace CleanArchDemo1.Application
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetStudents();
        StudentModel GetStudentById(int id);
        StudentModel Create(StudentModel student);
        StudentModel Update(StudentModel student);
        StudentModel Delete(int id);
    }
}
