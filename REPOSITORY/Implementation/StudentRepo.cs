using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.DTOS;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.REPOSITORY.Interface;

namespace SCHOOL_REGISTER.REPOSITORY.Implementation
{
    public class StudentRepo : IStudentRepo
    {
        public ApplContext appcontext = new();
        public FileAppContext fileApp = new();
        public StudentRepo()
        {
            ReadStudentsFromFile();
        }

        public void AddToFile(Student student)
        {
            try
            {
                using (var str = new StreamWriter(fileApp.Students, true))
                {
                    str.WriteLine(student.ToString());
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }

        public bool Check(string RegNumber)
        {
            return appcontext.Students.Any(s => s.RegNumber == RegNumber);
        }

        public void ClearAndUpdateFile(string filePath)
        {
           try
            {
               using(FileStream files = new(fileApp.Students, FileMode.Truncate))
               {
                System.Console.WriteLine("File Cleared!");
               }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine($"An error occured : {ex.Message}");
            }
           RefreshFile();
           
        }

        public void Create(Student student)
        {
            appcontext.Students.Add(student);
            AddToFile(student);
        }

        public int CreateId()
        {
            return appcontext.Students.Count + 1;
        }

        public List<Student> GetAll()
        {
           return appcontext.Students.Where(s=> s.IsDeleted == false).ToList();
        }

        public Student GetById(int Id)
        {
            return appcontext.Students.SingleOrDefault(s => s.Id == Id);
        }

        public Student GetByRegNumber(string RegNumber)
        {
            return appcontext.Students.SingleOrDefault(s => s.RegNumber == RegNumber);
        }

        public void ReadStudentsFromFile()
        {
            try
            {
                var students = File.ReadLines(fileApp.Students);
                foreach (var student in students)
                {
                    appcontext.Students.Add(Student.ToStudent(student));
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            //   List<Student> AddressStringLocation = new();
            //    try
            // {
            //     using (StreamReader stream = new(fileApp.Students))
            //     {
            //        string texts = stream.ReadLine();
            //        while(texts != null)
            //        {
            //           AddressStringLocation.Add(Student.ToStudent(texts));
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
                using (var str = new StreamWriter(fileApp.Students))
                {
                    foreach (var student in appcontext.Students)
                    {
                        str.WriteLine(student.ToString());
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