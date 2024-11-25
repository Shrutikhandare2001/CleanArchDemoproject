using CleanArchDemo1.Domain.Models;

namespace CleanArchDemo1.Application.UseCases.Student.CreateStudents
{
    public class CreateStudentsHandler
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public CreateStudentsResponse Handle(CreateStudentsRequest request)
        {
            var student = new StudentModel();

            student.Name = request.Name;
            student.City = request.City;
           

            _studentRepository.Create(student);

            CreateStudentsResponse response = new CreateStudentsResponse(student.Id, student.Name, student.City);
            return response;
        }
    }
}