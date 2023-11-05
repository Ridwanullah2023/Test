using System.IO.Pipes;
using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.REPOSITORY.Interface;

namespace SCHOOL_REGISTER.REPOSITORY.Implementation
{
    public class WeekLayoutRepo : IWeekLayOutRepo
    {

       public ApplContext appcontext = new();
       public FileAppContext _file = new();
        public void AddToFile(WeekLayOut layOut)
        {
            try
            {
                using (StreamWriter str = new(_file.WeekLayOuts, true))
                {
                    str.WriteLine(layOut.ToString());
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
               using(FileStream files = new(_file.WeekLayOuts, FileMode.Truncate))
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
                using (StreamWriter str = new(_file.WeekLayOuts))
                {
                    foreach (var item in appcontext.WeekLayOuts)
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

        public void Create(WeekLayOut layout)
        {
            appcontext.WeekLayOuts.Add(layout);
            AddToFile(layout);
        }

        public int CreateId()
        {
           return appcontext.WeekLayOuts.Count +1;
        }

        public WeekLayOut Get(int Id)
        {
            return appcontext.WeekLayOuts.SingleOrDefault(w => w.Id == Id);
        }

        public List<WeekLayOut> GetAll()
        {
            return appcontext.WeekLayOuts.Where(w => w.IsDeleted == false).ToList();
        }

        public void ReadWeekLayoutsFromFile()
        {
            // try
            // {
            //   var layouts = File.ReadLines(_file.WeekLayOuts);
            //   foreach(var layout in layouts)
            //   {
            //        appcontext.WeekLayOuts.Add(WeekLayOut.ToWeekLayOut(layout));
            //   }

            // }
            // catch (Exception ex)
            // {
            //     System.Console.WriteLine(ex.Message);
            // }
              List<WeekLayOut> AddressStringLocation = new();
               try
            {
                using (StreamReader stream = new(_file.WeekLayOuts))
                {
                   string texts = stream.ReadLine();
                   while(texts != null)
                   {
                      AddressStringLocation.Add(WeekLayOut.ToWeekLayOut(texts));
                   }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RefreshFile()
        {
            try
            {
              using(var str = new StreamWriter(_file.WeekLayOuts))
              {
                  foreach(var layout in appcontext.WeekLayOuts)
                  {
                    str.WriteLine(layout.ToString());
                  }
              }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}