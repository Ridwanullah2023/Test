using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.REPOSITORY.Interface;

namespace SCHOOL_REGISTER.REPOSITORY.Impplementation
{

    public class AddressRepo : IAdressRepo
    {
        public ApplContext _appContext = new();
        public FileAppContext _fileAppContxt = new();

        public AddressRepo()
        {
            ReadAddressesFromFile();
        }
        public void AddToFile(Address address)
        {
            try
            {
                using (StreamWriter stream = new(_fileAppContxt.Addresses, true))
                {
                    stream.WriteLine(address.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ClearAndUpdateFile(string filePath)
        {
            try
            {
               using(FileStream files = new(_fileAppContxt.Addresses, FileMode.Truncate))
               {
                System.Console.WriteLine("File Cleared!");
               }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"An error occured : {ex.Message}");
            }
             try
            {
                using (StreamWriter str = new(_fileAppContxt.Addresses))
                {
                    foreach (var item in _appContext.Addresses)
                    {
                        str.WriteLine(item.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
           
        }

        public void CreateAddress(Address address)
        {
            _appContext.Addresses.Add(address);
            AddToFile(address);
        }

        public int CreateId()
        {
            return _appContext.Addresses.Count + 1;
        }

        public Address GetAddressById(int Id)
        {
            return _appContext.Addresses.SingleOrDefault(a => a.Id == Id);
        }

        public Address GetAddressByState(string state)
        {
            return _appContext.Addresses.SingleOrDefault(a => a.State == state);
        }

        public List<Address> GetAllAddresses()
        {
            return _appContext.Addresses.Where(address => address.IsDeleted == false).ToList();
        }

      

        public void ReadAddressesFromFile()
        {
            try
            {
                var addresses = File.ReadAllLines(_fileAppContxt.Addresses);
                foreach (var address in addresses)
                {
                    _appContext.Addresses.Add(Address.ToAddress(address));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // List<Address> AddressStringLocation = new();
            //    try
            // {
            //     using (StreamReader stream = new StreamReader(@"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\Addresses.txt"))
            //     {
            //         Console.WriteLine("Hello");
            //         string texts;
            //        while((texts = stream.ReadLine()) != null)
            //        {
            //           AddressStringLocation.Add(Address.ToAddress(texts));
            //        }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
            
        }

        public void RefreshFile()
        {
            try
            {
                using (StreamWriter str = new(_fileAppContxt.Addresses))
                {
                    foreach (var item in _appContext.Addresses)
                    {
                        str.WriteLine(item.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}