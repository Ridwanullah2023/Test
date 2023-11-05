using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.REPOSITORY.Interface;

namespace SCHOOL_REGISTER.REPOSITORY.Implementation
{
    public class BasicClassRepo : IBasicClassRepo
    {
        public ApplContext _appContext = new();
        public FileAppContext _fileAppContext = new();
        public BasicClassRepo()
        {
            ReadClassesFromFile();
        }
        public void AddToFile(BasicClass basic)
        {
            try
            {
                using (StreamWriter str = new(_fileAppContext.BasicClasses, true))
                {
                    str.WriteLine(basic.ToString());
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
               using(FileStream files = new(_fileAppContext.BasicClasses, FileMode.Truncate))
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
            //     using (StreamWriter str = new(_fileAppContext.BasicClasses))
            //     {
            //         foreach (var item in _appContext.BasicClasses)
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

        public void Create(BasicClass basic)
        {
            _appContext.BasicClasses.Add(basic);
            CreateId();
            AddToFile(basic);

        }

        public int CreateId()
        {
            return _appContext.BasicClasses.Count + 1;
        }

        public BasicClass Get(int Id)
        {

            return _appContext.BasicClasses.SingleOrDefault(c => c.Id == Id);

        }

        public List<BasicClass> GetAll()
        {
            return _appContext.BasicClasses.Where(a => a.IsDeleted == false).ToList();
        }

        public void ReadClassesFromFile()
        {
            try
            {
                var classes = File.ReadAllLines(_fileAppContext.BasicClasses);
                foreach (var clas in classes)
                {
                    _appContext.BasicClasses.Add(BasicClass.ToBasicClass(clas));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //   List<BasicClass> AddressStringLocation = new();
            //    try
            // {
            //     using (StreamReader stream = new(_fileAppContext.BasicClasses))
            //     {
            //        string texts = stream.ReadLine();
            //        while(texts != null)
            //        {
            //           AddressStringLocation.Add(BasicClass.ToBasicClass(texts));
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
                using (StreamWriter str = new(_fileAppContext.BasicClasses))
                {
                    foreach (var item in _appContext.BasicClasses)
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