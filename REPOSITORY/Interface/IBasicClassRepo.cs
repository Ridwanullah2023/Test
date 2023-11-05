using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.REPOSITORY.Interface
{
    public interface IBasicClassRepo
    {
        void Create(BasicClass basic);
        BasicClass Get(int Id);
         int CreateId();
        List<BasicClass> GetAll();
        void AddToFile(BasicClass basic);
        void RefreshFile();
        void ReadClassesFromFile();
         void ClearAndUpdateFile(string filePath);
    }
}