namespace CleanArchDemo1.Application.UseCases.Student.GetStudentById
{
    public class GetStudentByIdHandler
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public GetStudentByIdResponse Handle(int Id)
        {
            var student = _studentRepository.GetStudentById(Id);

            GetStudentByIdResponse response = new GetStudentByIdResponse(student.Id, student.Name, student.City);
            return response;
        }
    }

}
