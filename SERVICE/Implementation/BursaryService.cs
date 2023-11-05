using System.Runtime.InteropServices;
using SCHOOL_REGISTER.CONTEXT;
using SCHOOL_REGISTER.DTOS;
using SCHOOL_REGISTER.ENTITY;
//using System.Speech.Synthesis;
using SCHOOL_REGISTER.REPOSITORY.Implementation;
using SCHOOL_REGISTER.REPOSITORY.Impplementation;
using SCHOOL_REGISTER.REPOSITORY.Interface;
using SCHOOL_REGISTER.SERVICE.Interface;

namespace SCHOOL_REGISTER.SERVICES.Implementation
{

    public class BursaryService : IBursaryService
    {
        public FileAppContext _fileApp = new();
        public IAdressRepo adressRepo = new AddressRepo();
        public IAttendanceRepo attendabceRepo = new AttendanceRepo();
        public IBasicClassRepo basicClass = new BasicClassRepo();
        public IGuardianRepo guardianRepo = new GuardianRepo();
        public IProfileRepo profileRepo = new ProfileRepo();
        public IStudentRepo studentRepo = new StudentRepo();
        public WeekLayoutRepo weekLayOut = new WeekLayoutRepo();

        public bool Delete(int id)
        {
            var student = studentRepo.GetById(id);
            var exists = studentRepo.Check(student.RegNumber);
            if (exists)
            {
                student.IsDeleted = true;
                var address = adressRepo.GetAddressById(student.AddressId);
                address.IsDeleted = true;
                var guardian = guardianRepo.Get(student.GuardianId);
                guardian.IsDeleted = true;
                var profile = profileRepo.Get(student.ProfileId);
                profile.IsDeleted = true;
                studentRepo.RefreshFile();
                adressRepo.RefreshFile();
                guardianRepo.RefreshFile();
                profileRepo.RefreshFile();
                System.Console.WriteLine($"{profile.FirstName} {profile.LastName} successfully deleted!");
                // string textt = $"{profile.FirstName} {profile.LastName} successfully deleted!";
                // ReadOutMyMessage(textt);
                return true;
            }
            System.Console.WriteLine("student not found");
            // string text = "student not found";
            // ReadOutMyMessage(text);
            return false;
        }

        public StudentDto Get(int Id)
        {
            var student = studentRepo.GetById(Id);
            var profile = profileRepo.Get(student.ProfileId);
            var address = adressRepo.GetAddressById(student.AddressId);
            var classcheck = basicClass.Get(student.BasicClassId);
            var guardian = guardianRepo.Get(student.GuardianId);
            var studentObj = new StudentDto()
            {
                City = address.City,
                Department = classcheck.Department,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                DOB = profile.DOB,
                Gender = profile.Gender,
                GuardianFirstName = guardian.FirstName,
                GuardianLastName = guardian.LastName,
                GuardianPhoneNumber = guardian.PhoneNumber,
                HouseNumber = address.HouseNumber,
                Level = classcheck.Level,
                ProfileId = profile.Id,
                State = address.State,
                StreetName = address.StreetName,
                TermlyFees = student.TermlyFees

            };
            System.Console.WriteLine($"{studentObj.FirstName}, {studentObj.LastName}, {studentObj.DOB}, {studentObj.Gender}, {studentObj.City}");
            System.Console.WriteLine("");
            return studentObj;
        }

        public List<StudentDto> GetAll()
        {
            var students = studentRepo.GetAll();
            var Profiles = profileRepo.GetAll();
            var studentsList = Profiles.Select(p => new StudentDto
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Gender = p.Gender,
                StudentRegNumber = p.StudentRegNumber,

            }).ToList();
            System.Console.WriteLine("==>    LIST OF ALL STUDENTS    <==");
            // string text = "HERE'S THE LIST OF ALL STUDENTS";
            // ReadOutMyMessage(text);
            foreach (var student in studentsList)
            {
                System.Console.WriteLine("First Name\tLast Name\tGender\tRegistration Number");
                System.Console.WriteLine($"{student.FirstName}       {student.LastName}      {student.Gender}      {student.StudentRegNumber}");

            }

            return studentsList;
        }

        public List<StudentDto> GetAllDebtors()
        {
            var students = studentRepo.GetAll();
            var Profiles = profileRepo.GetAll();
            var studentsList = Profiles.Select(p => new StudentDto
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Gender = p.Gender,
                StudentRegNumber = p.StudentRegNumber,

            }).ToList();
            System.Console.WriteLine("<== List of All Debtors ==>");
            // string text = "HERE'S THE LIST OF ALL DEBTORS";
            // ReadOutMyMessage(text);
            System.Console.WriteLine();
            foreach (var student in studentsList)
            {
                if (student.Payment < 0)
                {
                    System.Console.WriteLine("First Name\tLast Name\tGender\tRegistration Number");
                    System.Console.WriteLine($"{student.FirstName}        {student.LastName}      {student.Gender}      {student.StudentRegNumber}");
                }

                System.Console.WriteLine("There are no debtors at the moment");
                // string texTt = "There are no debtors at the moment";
                // ReadOutMyMessage(texTt);
                System.Console.WriteLine();
            }

            return studentsList;
        }

        public AttendanceDto GetAttendance()
        {
            throw new NotImplementedException();
        }

        public StudentDto GetByRegNumber(string RegNumber)
        {
            var student = studentRepo.GetByRegNumber(RegNumber);
            var profile = profileRepo.Get(student.ProfileId);
            var address = adressRepo.GetAddressById(student.AddressId);
            var classcheck = basicClass.Get(student.BasicClassId);
            var guardian = guardianRepo.Get(student.GuardianId);
            if (student == null)
            {
                System.Console.WriteLine($"Student with Registration Number {RegNumber} not found");
                // string texTt = $"Student with Registration Number {RegNumber} not found";
                // ReadOutMyMessage(texTt);
            }
            System.Console.WriteLine($"{profile.FirstName} is found!");
            // string T = $"Student with Registration Number {RegNumber} not found";
            // ReadOutMyMessage(T);

            return new StudentDto()
            {
                City = address.City,
                Department = classcheck.Department,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                DOB = profile.DOB,
                Gender = profile.Gender,
                GuardianFirstName = guardian.FirstName,
                GuardianLastName = guardian.LastName,
                GuardianPhoneNumber = guardian.PhoneNumber,
                HouseNumber = address.HouseNumber,
                Level = classcheck.Level,
                ProfileId = profile.Id,
                State = address.State,
                StreetName = address.StreetName,
                TermlyFees = student.TermlyFees

            };
            System.Console.WriteLine();
        }

        public bool MarkRegister(int Id)
        {
            var student = studentRepo.GetById(Id);
            throw new NotImplementedException();
        }

        public bool PayTuitionFees(string RegNumber, double WalletBalance)
        {
            var student = studentRepo.GetByRegNumber(RegNumber);
            if (student != null)
            {
                student.WalletBalance += WalletBalance;

                if (student.TermlyFees <= student.WalletBalance)
                {
                    System.Console.WriteLine($"Payment of #{WalletBalance} has been made!");
                    // string texTtt = $"Payment of {WalletBalance} naira has been made";
                    // ReadOutMyMessage(texTtt);
                    student.WalletBalance -= student.TermlyFees;
                    if (student.WalletBalance < 0)
                    {
                        System.Console.WriteLine($"Your deficit balance is #{student.WalletBalance}");
                        // string texTT = $"Your deficit balance is {student.WalletBalance} naira";
                        // ReadOutMyMessage(texTT);
                    }
                    System.Console.WriteLine($"You have #{student.WalletBalance} left in your wallet");
                    // string texT = $"Student with the Registration Number {student.RegNumber} has {student.WalletBalance} naira left in their wallet";
                    // ReadOutMyMessage(texT);
                    
                      studentRepo.RefreshFile();
                }
                return true;
            }
            System.Console.WriteLine("Student not found!");
            // string texTt = $"Student with the Registration Number {student.RegNumber} not found";
            // ReadOutMyMessage(texTt);
            return false;
        }
        // public void ReadOutMyMessage(string textToRead)
        // {
        //     using (SpeechSynthesizer spch = new())
        //     {
        //         spch.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
        //         spch.Speak(textToRead);
        //     }
        // }
        public StudentDto Register(RegistrationRequestModel model)
        {
            var exists = studentRepo.Check(model.RegNumber);
            if (exists)
            {
                System.Console.WriteLine($"user with the Registration Number {model.RegNumber} already exists");
                // string texTtt = $"user with the Registration Number {model.RegNumber} already exists";
                // ReadOutMyMessage(texTtt);
            }

            var Address = new Address()
            {
                Id = adressRepo.CreateId(),
                City = model.City,
                HouseNumber = model.HouseNumber,
                StreetName = model.StreetName,
                State = model.State,
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };
            adressRepo.CreateAddress(Address);

            var profile = new Profile()
            {
                Id = profileRepo.CreateId(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DOB = model.DOB,
                StudentRegNumber = model.RegNumber,
                CreatedAt = DateTime.Now,
                IsDeleted = false,

            };

            profileRepo.Create(profile);

            var guardian = new Guardian()
            {
                Id = guardianRepo.CreateId(),
                FirstName = model.GuardianFirstName,
                LastName = model.GuardianLastName,
                PhoneNumber = model.GuardianPhoneNumber,
                AddressId = Address.Id,
                CreatedAt = DateTime.Now,
                IsDeleted = false,

            };
            guardianRepo.Create(guardian);


            var student = new Student()
            {
                Id = studentRepo.CreateId(),
                RegNumber = model.RegNumber,
                AddressId = Address.Id,
                BasicClassId = model.BasicClassId,
                ProfileId = profile.Id,
                CreatedAt = DateTime.Now,
                GuardianId = guardian.Id,
                IsDeleted = false,
                TermlyFees = model.TermlyFees,
                WalletBalance = model.Payment,
                WeekLayoutId = weekLayOut.CreateId()


            };
            studentRepo.Create(student);

            var newClass = new BasicClass()
            {
                Level = model.Level,
                Department = model.Department,
                Id = model.BasicClassId,
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };
            basicClass.Create(newClass);
            System.Console.WriteLine($"Great! {model.FirstName} {model.LastName} has just been registered successfully!");
            // string texTt = $"Great! {model.FirstName} {model.LastName} has just been registered successfully!";
            // ReadOutMyMessage(texTt);

            return new StudentDto()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Department = newClass.Department,
                Level = newClass.Level,
                TermlyFees = student.TermlyFees,
                HouseNumber = Address.HouseNumber,
                StudentId = student.Id,
                StreetName = Address.StreetName,
                City = Address.City,
                State = Address.City,
                DOB = profile.DOB,
                Gender = profile.Gender,
                GuardianFirstName = guardian.FirstName,
                GuardianLastName = guardian.LastName,
                GuardianPhoneNumber = guardian.PhoneNumber,
                Payment = student.WalletBalance,
                BasicClassId = newClass.Id,
                ProfileId = profile.Id,
                StudentRegNumber = student.RegNumber

            };
        }

        public StudentDto Update(UpdateStudentRequestModel model)
        {

            var exists = studentRepo.Check(model.RegNumber);
            if (!exists)
            {
                System.Console.WriteLine("user does not exist");
                // string text = "user does not exist";
                // ReadOutMyMessage(text);
            }
            var student = studentRepo.GetByRegNumber(model.RegNumber);
            var profile = profileRepo.Get(student.ProfileId);
            var newClass = basicClass.Get(student.BasicClassId);
            var Address = adressRepo.GetAddressById(student.AddressId);
            var guardian = guardianRepo.Get(student.GuardianId);
            if (!exists)
            {
                System.Console.WriteLine($"Student with the registration number {model.RegNumber} not found!");
                // string text = $"Student with the registration number {model.RegNumber} not found!";
                // ReadOutMyMessage(text);
            }

            var updStudent = new Student()
            {
                AddressId = student.AddressId,
                BasicClassId = student.BasicClassId,
                CreatedAt = student.CreatedAt,
                GuardianId = student.GuardianId,
                Id = student.Id,
                IsDeleted = student.IsDeleted,
                ProfileId = student.ProfileId,
                RegNumber = student.RegNumber,
                TermlyFees = student.TermlyFees,
                WalletBalance = student.WalletBalance,
                WeekLayoutId = student.WeekLayoutId

            };
            var updProfile = new Profile()
            {
                CreatedAt = profile.CreatedAt,
                DOB = model.DOB,
                FirstName = model.FirstName,
                Gender = profile.Gender,
                Id = profile.Id,
                IsDeleted = profile.IsDeleted,
                LastName = model.LastName,
                StudentRegNumber = profile.StudentRegNumber
            };
            var updClass = new BasicClass()
            {
                CreatedAt = newClass.CreatedAt,
                Department = model.Department,
                Id = newClass.Id,
                IsDeleted = newClass.IsDeleted,
                Level = model.Level
            };

            var updAddress = new Address()
            {
                City = model.City,
                CreatedAt = Address.CreatedAt,
                HouseNumber = model.HouseNumber,
                Id = Address.Id,
                IsDeleted = Address.IsDeleted,
                State = model.State,
                StreetName = model.StreetName
            };
            var updGuardian = new Guardian()
            {
                AddressId = guardian.AddressId,
                CreatedAt = guardian.CreatedAt,
                FirstName = model.FirstName,
                Id = guardian.Id,
                LastName = model.LastName,
                PhoneNumber = model.GuardianPhoneNumber,
                IsDeleted = guardian.IsDeleted
            };
            //studentRepo.RefreshFile();
            studentRepo.ClearAndUpdateFile(_fileApp.Students);
            // profileRepo.RefreshFile();
            profileRepo.ClearAndUpdateFile(_fileApp.Profiles);
            //adressRepo.RefreshFile();
            adressRepo.ClearAndUpdateFile(_fileApp.Addresses);
            // basicClass.RefreshFile();
            basicClass.ClearAndUpdateFile(_fileApp.BasicClasses);
            guardianRepo.ClearAndUpdateFile(_fileApp.Guardians);
            return new StudentDto()
            {
                BasicClassId = updClass.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                City = model.City,
                Department = model.Department,
                Gender = updProfile.Gender,
                GuardianFirstName = model.FirstName,
                GuardianLastName = model.LastName,
                GuardianPhoneNumber = model.GuardianPhoneNumber,
                HouseNumber = model.HouseNumber,
                Level = model.Level,
                Payment = updStudent.WalletBalance,
                ProfileId = updProfile.Id,
                State = model.State,
                StreetName = model.StreetName,
                StudentId = updStudent.Id,
                StudentRegNumber = model.RegNumber
            };

            // StudentDto update = new();
            // update.City = model.City;
            // update.Department = model.Department;
            // update.DOB = model.DOB;
            // update.FirstName = model.FirstName;
            // update.LastName = model.LastName;
            // update.GuardianFirstName = model.GuardianFirstName;
            // update.GuardianLastName = model.GuardianLastName;
            // update.GuardianPhoneNumber = model.GuardianPhoneNumber;
            // update.HouseNumber = model.HouseNumber;
            // update.StreetName = model.StreetName;
            // update.State = model.State;
            // update.Department = model.Department;
            // update.TermlyFees = model.TermlyFees;
            // return update;

        }
    }
}