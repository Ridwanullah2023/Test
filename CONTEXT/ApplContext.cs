using SCHOOL_REGISTER.ENTITY;

namespace SCHOOL_REGISTER.CONTEXT
{
    public class ApplContext
    {
         public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<BasicClass> BasicClasses { get; set; } = new List<BasicClass>();
         public List<Guardian> Guardians { get; set; } = new List<Guardian>();
         public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<WeekLayOut> WeekLayOuts { get; set; } = new List<WeekLayOut>();
    }
}