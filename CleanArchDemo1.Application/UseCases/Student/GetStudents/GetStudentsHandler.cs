using CleanArchDemo1.Application;
using CleanArchDemo1.Domain.Models;

namespace CleanArchDemo1.Application.UseCases.Student.GetStudents
{

    public class GetStudentsHandler
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<StudentModel> Handle()
        {
            var response = _studentRepository.GetStudents();
            return response;
        }

    }
}
