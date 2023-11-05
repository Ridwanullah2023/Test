using SCHOOL_REGISTER.DTOS;
using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.REPOSITORY.Interface
{
    public interface IStudentRepo
    {
        void Create(Student student);
        int CreateId();
        bool Check(string RegNumber);
        Student GetByRegNumber(string RegNumber);
        Student GetById(int Id);
        List<Student> GetAll();
        void RefreshFile();
        void AddToFile(Student student);
        void ReadStudentsFromFile();
        void ClearAndUpdateFile(string filePath);
    }
}