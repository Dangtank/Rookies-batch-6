using Day1.Data;
using Day1.Models;

namespace Day1.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(StudentManagementContext context) : base(context)
    {
    }
}