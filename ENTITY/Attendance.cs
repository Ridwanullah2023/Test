namespace SCHOOL_REGISTER.ENTITY
{
    public class Attendance : AuditableEntity
    {
        public DateTime ResumedAt {get; set;}
        public DateTime LeftSchoolAt {get; set;}
        public int WeeklyPresence {get; set;}
        public string StudentRegNumber {get; set;} = default!;
        public int BasicClassId {get; set;}
        public bool IsPresent {get; set;}

         public static Attendance ToAttendance(string sep)
        {
            var Position = sep.Split('\t');
            var Attendance = new Attendance()
            {
             Id = int.Parse(Position[0]),
             CreatedAt = DateTime.Parse(Position[1]),
             IsDeleted = bool.Parse(Position[2]),
             ResumedAt = DateTime.Parse(Position[3]),
             LeftSchoolAt = DateTime.Parse(Position[4]),
             WeeklyPresence = int.Parse(Position[5]),
             StudentRegNumber = Position[6],
             BasicClassId = int.Parse(Position[7]),
             IsPresent = bool.Parse(Position[8])
            };
            return Attendance;
        }

         public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{IsDeleted}\t{ResumedAt}\t{LeftSchoolAt}\t{WeeklyPresence}\t{StudentRegNumber}\t{BasicClassId}\t{IsPresent}";
        }
    }
}