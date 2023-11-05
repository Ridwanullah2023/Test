namespace SCHOOL_REGISTER.CONTEXT
{
    public class FileAppContext
    {
        public string path = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files";
        public string Students = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\Students.txt";
        public string Addresses = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\Addresses.txt";
        public string BasicClasses = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\BasicClasses.txt";
        public string Guardians = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\Guardians.txt";
        public string Attendances = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\Attendances.txt";
        public string Profiles = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\Profiles.txt";
        public string WeekLayOuts = @"C:\Users\Aboo-l-Marjaan\Desktop\CLASSES\CONSOLEAPPS\SCHOOL\CONTEXT\All-Files\WeekLayOuts.txt";

        public void CreateWeekLayOutsFile()
        {
            if (!File.Exists(WeekLayOuts))
            {
                string fileName = "WeekLayOuts.txt";
                string wkl = Path.Combine(path, fileName);
                var stream = File.Create(wkl);
                stream.Flush();
            }
          
        }
        public void CreateProfilesFile()
        {
            if (!File.Exists(Profiles))
            {
                string fileName = "Profiles.txt";
                string prf = Path.Combine(path, fileName);
                var stream = File.Create(prf);
                stream.Flush();
            }

        }
        public void CreateAttendanceFile()
        {
            if (!File.Exists(Attendances))
            {
                string fileName = "Attendances.txt";
                string att = Path.Combine(path, fileName);
                var stream =  File.Create(att);
                stream.Flush();
               
            }

        }
        public void CreateGuardiansFile()
        {
            if (!File.Exists(Guardians))
            {
                string fileName = "Guardians.txt";
                string grd = Path.Combine(path, fileName);
              var stream =   File.Create(grd);
              stream.Flush();
            }

        }
        public void CreateBasicClassesFile()
        {
            if (!File.Exists(BasicClasses))
            {
                string fileName = "BasicClasses.txt";
                string clss = Path.Combine(path, fileName);
               var stream =  File.Create(clss);
               stream.Flush();
            }

        }
        public void CreateStudentsFile()
        {
            if (!File.Exists(Students))
            {
                string fileName = "Students.txt";
                string std = Path.Combine(path, fileName);
                var stream = File.Create(std);
                stream.Flush();
            }

        }

        public void CreateAddressesFile()
        {
            if (!File.Exists(Addresses))
            {
                string fileName = "Addresses.txt";
                string add = Path.Combine(path, fileName);
                var stream = File.Create(add);
                stream.Close();
                
            }

        }

    }
}