using CleanArchDemo1.Application;

namespace CleanArchDemo1.Application.UseCases.Student.DeleteStudent
{
    public class DeleteStudentHandler
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public DeleteStudentResponse Handle(int Id)
        {
            var student = _studentRepository.Delete(Id);

            DeleteStudentResponse response = new DeleteStudentResponse(student.Id, student.Name, student.City);
            return response;
        }
    }
}
