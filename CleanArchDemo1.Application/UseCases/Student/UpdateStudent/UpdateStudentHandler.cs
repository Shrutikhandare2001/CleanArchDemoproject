using CleanArchDemo1.Domain.Models;

namespace CleanArchDemo1.Application.UseCases.Student.UpdateStudent
{
    public class UpdateStudentHandler
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public UpdateStudentResponse Handle(int id, UpdateStudentRequest request)
        {
            var student = new StudentModel();
            //student.Id = id;
            student.Name = request.Name;
            student.City = request.City;

            _studentRepository.Update(student);

            UpdateStudentResponse response = new UpdateStudentResponse(student.Id, student.Name, student.City);
            return response;
        }


    }
}
