namespace SCHOOL_REGISTER.ENTITY
{
    public class Student : AuditableEntity
    {
        public string RegNumber { get; set; } = default!;
        public int GuardianId { get; set; } 
        public int AddressId { get; set; }
        public int ProfileId {get; set;}
        public int BasicClassId { get; set; }
        public int WeekLayoutId { get; set; }
        public double TermlyFees { get; set; }
    public double WalletBalance {get; set;}
        
         public static Student ToStudent(string sep)
        {
            var Position = sep.Split('\t');
            var Student = new Student()
            {
             Id = int.Parse(Position[0]),
             CreatedAt = DateTime.Parse(Position[1]),
             IsDeleted = bool.Parse(Position[2]),
             RegNumber = Position[3],
             GuardianId = int.Parse(Position[4]),
             AddressId = int.Parse(Position[5]),
             BasicClassId = int.Parse(Position[6]),
             WeekLayoutId = int.Parse(Position[7]),
             TermlyFees = double.Parse(Position[8]),
             WalletBalance  = double.Parse(Position[8])
            };
            return Student;
        }

         public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{IsDeleted}\t{RegNumber}\t{GuardianId}\t{AddressId}\t{BasicClassId}\t{BasicClassId}\t{WeekLayoutId}\t{TermlyFees}\t{WalletBalance}";
        }
    }
}