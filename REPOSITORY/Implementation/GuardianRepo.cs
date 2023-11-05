using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.REPOSITORY.Interface;

namespace SCHOOL_REGISTER.REPOSITORY.Implementation
{
    public class GuardianRepo : IGuardianRepo
    {

        public ApplContext _appContext = new();
        public FileAppContext _file = new();
        public GuardianRepo()
        {
            ReadGuardiansFromFile();
        }
        public void AddToFile(Guardian guardian)
        {
            try
            {
                using (StreamWriter str = new(_file.Guardians, true))
                {
                    str.WriteLine(guardian.ToString());
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void ClearAndUpdateFile(string filePath)
        {
             try
            {
               using(FileStream files = new(_file.Guardians, FileMode.Truncate))
               {
                System.Console.WriteLine("File Cleared!");
               }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"An error occured : {ex.Message}");
            }
            //  try
            // {
            //     using (StreamWriter str = new(_file.Guardians))
            //     {
            //         foreach (var item in _appContext.Guardians)
            //         {
            //             str.WriteLine(item.ToString());
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
           
        }

        public void Create(Guardian guardian)
        {
            _appContext.Guardians.Add(guardian);
            AddToFile(guardian);

        }

        public int CreateId()
        {
            return _appContext.Guardians.Count + 1;

        }

        public Guardian Get(int Id)
        {
            return _appContext.Guardians.SingleOrDefault(g => g.Id == Id);
        }

        public List<Guardian> GetAll()
        {
            return _appContext.Guardians.Where(g => g.IsDeleted == false).ToList();
        }



        public void ReadGuardiansFromFile()
        {
            try
            {
                var guardians = File.ReadAllLines(_file.Guardians);
                foreach (var guardian in guardians)
                {
                    _appContext.Guardians.Add(Guardian.ToGuardian(guardian));
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            //   List<Guardian> AddressStringLocation = new();
            //    try
            // {
            //     using (StreamReader stream = new(_file.Guardians))
            //     {
            //        string texts = stream.ReadLine();
            //        while(texts != null)
            //        {
            //           AddressStringLocation.Add(Guardian.ToGuardian(texts));
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
                using (StreamWriter str = new(_file.Guardians))
                {
                    foreach (var guardian in _appContext.Guardians)
                    {
                        str.WriteLine(guardian.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}