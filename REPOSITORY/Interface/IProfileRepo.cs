using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.REPOSITORY.Interface
{
    public interface IProfileRepo
    {
        void Create(Profile profile);
         int CreateId();
        Profile Get(int Id);
        List<Profile> GetAll();
        void AddToFile(Profile profile);
        void RefreshFile();
        void ReadProfilesFromFile();
         void ClearAndUpdateFile(string filePath);
    }
}