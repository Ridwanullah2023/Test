using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.DTOS
{


    public class StudentDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DOB { get; set; }
        public int ProfileId { get; set; }
        public int StudentId { get; set; }
        public int HouseNumber { get; set; }
        public string StreetName { get; set; } = default!;
        public int BasicClassId { get; set; }
        public string City { get; set; } = default!;
        public string StudentRegNumber { get; set; } = default!;
        public string State { get; set; } = default!;
        public int Level { get; set; }
        public string Department { get; set; } = default!;
        public Gender Gender { get; set; }
        public string GuardianFirstName { get; set; } = default!;
        public string GuardianLastName { get; set; } = default!;
        public string GuardianPhoneNumber { get; set; } = default!;
        public double TermlyFees { get; set; }
        public double Payment { get; set; }

    }
    public class RegistrationRequestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DOB { get; set; }
        public int ProfileId { get; set; }
        public int HouseNumber { get; set; }
        public string RegNumber { get; set; } = $"CLH/ STD/{Guid.NewGuid().ToString().Substring(0, 4)}";
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public int AddressId { get; set; }
        public int GuardianId { get; set; }
        public int BasicClassId { get; set; }
        public int Level { get; set; }
        public string Department { get; set; } = default!;
        public Gender Gender { get; set; }
        public string GuardianFirstName { get; set; } = default!;
        public string GuardianLastName { get; set; } = default!;
        public string GuardianPhoneNumber { get; set; } = default!;
        public double TermlyFees { get; set; }
        public double Payment { get; set; }

    }

    public class UpdateStudentRequestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string RegNumber { get; set; } = default!;
        public DateTime DOB { get; set; }
        public int HouseNumber { get; set; }
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public int Level { get; set; }
        public string Department { get; set; } = default!;
        public string GuardianFirstName { get; set; } = default!;
        public string GuardianLastName { get; set; } = default!;
        public string GuardianPhoneNumber { get; set; } = default!;
        public double TermlyFees { get; set; }
    }
}