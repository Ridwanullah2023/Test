using SCHOOL_REGISTER.DTOS;

namespace SCHOOL_REGISTER.SERVICE.Interface
{
    public interface IBursaryService
    {
        StudentDto Register(RegistrationRequestModel model);
        StudentDto Get(int Id);
        StudentDto GetByRegNumber(string RegNumber);
        List<StudentDto> GetAll();
        AttendanceDto GetAttendance();
         List<StudentDto> GetAllDebtors();
         bool Delete(int id);
         bool MarkRegister(int Id);
         StudentDto Update(UpdateStudentRequestModel model);
         bool PayTuitionFees(string RegNumber, double WalletBalance);
        // void ReadOutMyMessage(string textToRead);
  
    }
}