using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.REPOSITORY.Interface
{
    public interface IAttendanceRepo
    {
        void CreateAttendance(Attendance attendance);
        Attendance GetAttendance(int id);
         int CreateId();
        List<Attendance> GetAllAttenndance();
        void AddToFile(Attendance attendance);
        void RefreshFile();
        void ReadAttendancesFromFile();
         void ClearAndUpdateFile(string filePath);
    }
}