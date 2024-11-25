using CleanArchDemo1.Application;
using CleanArchDemo1.Domain.Models;

namespace CleanArchDemo1.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsDbContext _context;

        public StudentRepository(StudentsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentModel> GetStudents() 
        {
            var res = _context.Students;
            return res;
        }

        public StudentModel GetStudentById(int id)
        {
            var response = _context.Students.FirstOrDefault(student => student.Id == id);
            return response;
        }

        public StudentModel Create(StudentModel student)
        {
            var res = _context.Students.Add(student);
            _context.SaveChangesAsync();
            return student;
        }

        public StudentModel Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChangesAsync();  
            }
            return student;
        }

        public StudentModel Update(StudentModel student1)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student1.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student1.Name;
                existingStudent.City = student1.City;
                _context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }
    }
}


//using CleanArchDemo1.Application;
//using CleanArchDemo1.Domain.Models;
//using CleanArchDemo1.Repository.DbContext;

//namespace CleanArchDemo1.Repository
//{
//    public class StudentRepository : IStudentRepository
//    {
//        private readonly StudentsDbContext _context;

//        public StudentRepository(StudentsDbContext context)
//        {
//            _context = context;
//        }


//        public Student GetAll()
//        {
//            return _context.Students;
//        }

//        public Student GetById(int id)
//        {
//            var response = Students.FirstOrDefault(student => student.Id == id);
//            if (response == null)
//            {
//                return null;
//            }
//            return response;
//        }

//        public Student Create(Student student)
//        {
//            Students.Add(student);
//            return student;
//        }

//        public Student Delete(int id)
//        {
//            var response = Students.FirstOrDefault(student => student.Id == id);
//            if (students != null)
//            {
//                students.Remove(response);
//            }
//            return response;
//        }

//        public Student Update(Student student1)
//        {
//            var updatedstudent = students.FirstOrDefault(student => student.Id == student1.Id);
//            if (updatedstudent != null)
//            {
//                updatedstudent.City = student1.City;
//                updatedstudent.Name = student1.Name;
//                return updatedstudent;
//            }
//            return updatedstudent;

//        }
//    }
//}
