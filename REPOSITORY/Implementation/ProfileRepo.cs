using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.REPOSITORY.Interface;

namespace SCHOOL_REGISTER.REPOSITORY.Implementation
{
    public class ProfileRepo : IProfileRepo
    {
        public ProfileRepo()
        {
            ReadProfilesFromFile();
        }
        public ApplContext _appContext = new();
        public FileAppContext _file = new();

        public void AddToFile(Profile profile)
        {
            try
            {
                using (StreamWriter str = new(_file.Profiles, true))
                {
                    str.WriteLine(profile.ToString());
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        public Profile Get(int Id)
        {
            return _appContext.Profiles.SingleOrDefault(p => p.Id == Id);
        }

        public List<Profile> GetAll()
        {
            return _appContext.Profiles.Where(p => p.IsDeleted == false).ToList();
        }

        public void ReadProfilesFromFile()
        {
            try
            {
                var profiles = File.ReadAllLines(_file.Profiles);
                foreach (var profile in profiles)
                {                    
                    _appContext.Profiles.Add(Profile.ToProfile(profile));

                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            //   List<Profile> AddressStringLocation = new();
            //    try
            // {
            //     using (StreamReader stream = new(_file.Profiles))
            //     {
            //        string texts = stream.ReadLine();
            //        while(texts != null)
            //        {
            //           AddressStringLocation.Add(Profile.ToProfile(texts));
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
                using (StreamWriter str = new(_file.Profiles))
                {
                    foreach (var profile in _appContext.Profiles)
                    {
                        str.WriteLine(profile.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            };
        }

        public void Create(Profile profile)
        {
            _appContext.Profiles.Add(profile);
            AddToFile(profile);
        }

        public int CreateId()
        {
            return _appContext.Profiles.Count + 1;
        }

        public void ClearAndUpdateFile(string filePath)
        {
            try
            {
               using(FileStream files = new(_file.Profiles, FileMode.Truncate))
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
            //     using (StreamWriter str = new(_file.Profiles))
            //     {
            //         foreach (var item in _appContext.Profiles)
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
    }
}