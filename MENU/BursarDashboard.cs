using Microsoft.VisualBasic;
using SCHOOL_REGISTER.DTOS;
using SCHOOL_REGISTER.ENTITY;
using SCHOOL_REGISTER.SERVICE.Interface;
using SCHOOL_REGISTER.SERVICES.Implementation;

namespace SCHOOL_REGISTER.MENU
{
    public class BursarDashboard
    {
        private readonly IBursaryService _bursaryService = new BursaryService();
        public void LoadBurserDashBoard()
        {
            Console.WriteLine("Hi! What Would You Like To Do? \nKindly Press The Appropriate Option To Begin");
            // string texTt = "Welcome! What Would You Like To Do? Kindly Press The Appropriate Option To Begin";
            // _bursaryService.ReadOutMyMessage(texTt);
            Console.WriteLine("");
            Console.WriteLine("1. Register a student");
            Console.WriteLine("2. Mark Student's Attendance");
            Console.WriteLine("3. Get a Student by Id");
            Console.WriteLine("4. Get a Student by Registration Number");
            Console.WriteLine("5. Update a Student");
            Console.WriteLine("6. Make Tuition Payment");
            Console.WriteLine("7. Get All Students in School");
            Console.WriteLine("8. Delete a Student");
            Console.WriteLine("9. View All Debtors");
            Console.WriteLine("10. ");
            Console.WriteLine("12. ");
            Console.WriteLine("13. ");

            int option = int.Parse(Console.ReadLine());
            bool run = true;
            while (run)
            {
                switch (option)
                {
                    case 1:
                        RegisterSudent();
                        LoadBurserDashBoard();
                        break;

                    case 2:
                        MarkAttendance();
                        LoadBurserDashBoard();

                        break;

                    case 3:
                        GetStudentById();
                        LoadBurserDashBoard();

                        break;

                    case 4:
                        GetStudentByRegNo();
                        LoadBurserDashBoard();
                        break;

                    case 5:
                        Update();
                        LoadBurserDashBoard();
                        break;

                    case 6:
                        PayTuitionFees();
                        LoadBurserDashBoard();
                        break;

                    case 7:
                        GetAllStudents();
                        LoadBurserDashBoard();
                        break;

                    case 8:
                        Delete();
                        LoadBurserDashBoard();
                        break;

                    case 9:
                        GetDebtors();
                        LoadBurserDashBoard();
                        break;

                    case 10:
                        break;

                    case 11:
                        break;

                    case 12:
                        break;

                    case 13:
                        break;

                    default:
                        break;
                }
            }

        }
        void RegisterSudent()
        {
            System.Console.WriteLine("==> Student Details <==");
            System.Console.WriteLine();
            System.Console.WriteLine("Enter Student's First Name: ");
            string firstName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Last Name: ");
            string lastName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Date of Birth in the Format  YYYY-MM-DD: ");
            DateTime dOB = DateTime.Parse(Console.ReadLine());
            System.Console.WriteLine("Is the student male or Female, Press 1 for Male, Press 2 For Female");
            Gender gender = (Gender)int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Student's House Number: ");
            int houseNumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Student's Street name: ");
            string streetName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's City of Residence : ");
            string city = Console.ReadLine();
            System.Console.WriteLine("Enter Student's State of Residence : ");
            string state = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Class : ");
            int level = int.Parse(Console.ReadLine());
            System.Console.WriteLine("For Class Id, press 1 for Jss1, 2 for Jss2. . .6 for SS3");
            int basicClassId = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Student's Department : ");
            string department = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Guardian;s First Name: ");
            string guardianFirstName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Guardian's Last Name: ");
            string guardianLastName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Guardian's Phone Number: ");
            string guardianPhoneNumber = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Termly Fees: ");
            double termlyFees = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Student's current Payment: ");
            double payment = double.Parse(Console.ReadLine());


            RegistrationRequestModel newStudent = new()
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = dOB,
                HouseNumber = houseNumber,
                StreetName = streetName,
                City = city,
                State = state,
                Level = level,
                GuardianFirstName = guardianFirstName,
                GuardianLastName = guardianLastName,
                GuardianPhoneNumber = guardianPhoneNumber,
                Gender = gender,
                Department = department,
                TermlyFees = termlyFees,
                Payment = payment,
                BasicClassId = basicClassId

            };
            var student = _bursaryService.Register(newStudent);
            System.Console.WriteLine($"  {student.FirstName} {student.LastName} has been registered successfully!");
            System.Console.WriteLine("");
        }



        void MarkAttendance()
        {

        }
        void GetStudentByRegNo()
        {
            System.Console.WriteLine("Enter student's Registration Number");
            string RegNumber = Console.ReadLine();
            _bursaryService.GetByRegNumber(RegNumber);
        }
        void GetStudentById()
        {
            System.Console.WriteLine("Enter student's Id");
            int Id = int.Parse(Console.ReadLine());
            _bursaryService.Get(Id);
        }
        void GetAllStudents()
        {
            _bursaryService.GetAll();
        }
        void PayTuitionFees()
        {
            System.Console.Write("Enter student's Registration Number: ");
            string RegNumber = Console.ReadLine();
            System.Console.Write("How much do you wish to pay?");
            try
            {
                double WalletBalance = double.Parse(Console.ReadLine());
                while (WalletBalance < 0)
                {
                    System.Console.WriteLine("Enter a valid amount!");

                }
                _bursaryService.PayTuitionFees(RegNumber, WalletBalance);
            }
            catch (Exception msg)
            {
                System.Console.WriteLine(msg.Message);
            }

        }
        void GetAllWeeklyAttendance()
        {

        }
        void GetWeeklyAttendanceByRegNo()
        {

        }
        void GetDebtors()
        {
            _bursaryService.GetAllDebtors();
        }
        void Update()
        {
            System.Console.WriteLine("==> Student's Updated Details <==");
            System.Console.WriteLine();
            System.Console.WriteLine("Please Enter The Student's Registration Number");
            // string texTt = $"Please Enter The Student's Registration Number";
            // _bursaryService.ReadOutMyMessage(texTt);
            string regNumber = Console.ReadLine();
            //  string text = $"You've Entered {regNumber}. If this is not correct, please terminate and start again";
            // _bursaryService.ReadOutMyMessage(text);
            System.Console.WriteLine("Enter Student's First Name: ");
            string firstName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Last Name: ");
            string lastName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Date of Birth in the Format  YYYY-MM-DD: ");
            DateTime dOB = DateTime.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Student's House Number: ");
            int houseNumber = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Student's Street name: ");
            string streetName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's City of Residence : ");
            string city = Console.ReadLine();
            System.Console.WriteLine("Enter Student's State of Residence : ");
            string state = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Class : ");
            int level = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter Student's Department : ");
            string department = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Guardian;s First Name: ");
            string guardianFirstName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Guardian's Last Name: ");
            string guardianLastName = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Guardian's Phone Number: ");
            string guardianPhoneNumber = Console.ReadLine();
            System.Console.WriteLine("Enter Student's Termly Fees: ");
            double termlyFees = double.Parse(Console.ReadLine());

            UpdateStudentRequestModel updatedStudent = new()
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = dOB,
                HouseNumber = houseNumber,
                StreetName = streetName,
                City = city,
                State = state,
                Level = level,
                GuardianFirstName = guardianFirstName,
                GuardianLastName = guardianLastName,
                GuardianPhoneNumber = guardianPhoneNumber,
                Department = department,
                TermlyFees = termlyFees,
                RegNumber = regNumber
            };
            var update = _bursaryService.Update(updatedStudent);
            System.Console.WriteLine($"Details updated! Student's new name is {update.FirstName} {update.LastName} of {update.Department} department \nS\\he now lives in {update.HouseNumber}, {update.StreetName}, {update.City}, {update.State} State");
            System.Console.WriteLine("");
            //  string texTtt = $"Details updated! Student's new name is {update.FirstName} {update.LastName} of {update.Department} department \nS\\he now lives in {update.HouseNumber}, {update.StreetName}, {update.City}, {update.State} State";
            // _bursaryService.ReadOutMyMessage(texTtt);
        }

        void Delete()
        {
            System.Console.WriteLine("Please Enter Student's Id:");
            int Id = int.Parse(Console.ReadLine());
            _bursaryService.Delete(Id);
        }

    }
}