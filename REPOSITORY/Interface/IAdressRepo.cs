using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.REPOSITORY.Interface
{
    public interface IAdressRepo
    {
        void CreateAddress(Address address);
        Address GetAddressById(int Id);

        Address GetAddressByState(string state);
        int CreateId();
        List<Address> GetAllAddresses();
        void AddToFile(Address address);
        void RefreshFile();
        void ReadAddressesFromFile();
        void ClearAndUpdateFile(string filePath);
       
    }
}