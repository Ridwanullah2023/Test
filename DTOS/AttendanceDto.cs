using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.DTOS
{
    public class AttendanceDto
    {
        public DateTime ResumedAt { get; set; }
        public DateTime LeftSchoolAt { get; set; }
        public int WeeklyPresence { get; set; }
        public string StudentRegNumber { get; set; } = default!;
        public int BasicClassId { get; set; }
        public bool IsPresent { get; set; }
        public string RegNumber { get; set; } = default!;
        public string GuardianId { get; set; } = default!;
        public int AddressId { get; set; }
        public int WeekLayoutId { get; set; }
        public double TermlyFees { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public Gender Gender { get; set; }
    }

    public class PresenceRequestModel
    {
        public DateTime ResumedAt { get; set; } = DateTime.Now;
        public DateTime LeftSchoolAt { get; set; } = DateTime.Now;
        public string StudentRegNumber { get; set; } = default!;
        public bool IsPresent { get; set; }
    }

    public class UpdateAttendanceRequestModel
    {
        public bool IsPresent { get; set; }
        public int WeekLayoutId { get; set; }
    }
}