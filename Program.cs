// See https://aka.ms/new-console-template for more information

using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.MENU;

Console.WriteLine();
FileAppContext app = new();
app.CreateAddressesFile();
 app.CreateAttendanceFile();
app.CreateBasicClassesFile();
 app.CreateGuardiansFile();
 app.CreateProfilesFile();
 app.CreateStudentsFile();
 app.CreateWeekLayOutsFile();
 System.Console.WriteLine();
 BursarDashboard b = new();
 b.LoadBurserDashBoard();

