using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.REPOSITORY.Interface;

namespace SCHOOL_REGISTER.REPOSITORY.Implementation
{
    public class AttendanceRepo : IAttendanceRepo
    {

        public ApplContext _appcontext = new();
        public FileAppContext _fileAppContxt = new();

        public AttendanceRepo()
        {
            ReadAttendancesFromFile();
        }
        public void AddToFile(Attendance attendance)
        {
            try
            {
                using (StreamWriter stream = new(_fileAppContxt.Attendances, true))
                {
                    stream.WriteLine(attendance.ToString());
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
               using(FileStream files = new(_fileAppContxt.Attendances, FileMode.Truncate))
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
                using (StreamWriter str = new(_fileAppContxt.Attendances))
                {
                    foreach (var item in _fileAppContxt.Attendances)
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

        public void CreateAttendance(Attendance attendance)
        {
            _appcontext.Attendances.Add(attendance);
            CreateId();
            AddToFile(attendance);

        }

        public int CreateId()
        {

            return _appcontext.Attendances.Count + 1;
        }

        public List<Attendance> GetAllAttenndance()
        {
            return _appcontext.Attendances.Where(address => address.IsDeleted == false).ToList();
        }

        public Attendance GetAttendance(int id)
        {
            var attendance = _appcontext.Attendances.SingleOrDefault(a => a.Id == id);
            return attendance;
        }

        public void ReadAttendancesFromFile()
        {
            try
            {
                var attendances = File.ReadAllLines(_fileAppContxt.Attendances);
                foreach (var attendance in attendances)
                {
                    _appcontext.Attendances.Add(Attendance.ToAttendance(attendance));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //   List<Attendance> AddressStringLocation = new();
            //    try
            // {
            //     using (StreamReader stream = new(_fileAppContxt.Attendances))
            //     {
            //        string texts = stream.ReadLine();
            //        while(texts != null)
            //        {
            //           AddressStringLocation.Add(Attendance.ToAttendance(texts));
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
                using (StreamWriter str = new(_fileAppContxt.Attendances))
                {
                    foreach (var item in _appcontext.Attendances)
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