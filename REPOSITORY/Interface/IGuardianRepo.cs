using Microsoft.VisualBasic.FileIO;
using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.REPOSITORY.Interface
{
    public interface IGuardianRepo
    {
        void Create(Guardian guardian);
        Guardian Get(int Id);
         int CreateId();
        List<Guardian> GetAll();
        void AddToFile(Guardian guardian);
        void RefreshFile();
        void ReadGuardiansFromFile();
         void ClearAndUpdateFile(string filePath);
    }
}