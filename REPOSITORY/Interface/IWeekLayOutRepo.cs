using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.REPOSITORY.Interface
{
    public interface IWeekLayOutRepo
    {
        void Create(WeekLayOut layout);
        int CreateId();
        WeekLayOut Get(int Id);
        List<WeekLayOut> GetAll();
        void ReadWeekLayoutsFromFile();
        void AddToFile(WeekLayOut layOut);
        void RefreshFile();
        void ClearAndUpdateFile(string filePath);
    }
}