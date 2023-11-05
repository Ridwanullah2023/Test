namespace SCHOOL_REGISTER.ENTITY
{
    public class Profile : AuditableEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DOB { get; set; }
        public string StudentRegNumber { get; set; } = default!;
        public Gender Gender {get; set;}

         public static Profile ToProfile(string sep)
        {
            var Position = sep.Split('\t');
            var Profile = new Profile()
            {
             Id = int.Parse(Position[0]),
             CreatedAt = DateTime.Parse(Position[1]),
             IsDeleted = bool.Parse(Position[2]),
             FirstName = Position[3],
             LastName = Position[4],
             DOB = DateTime.Parse(Position[5]),
             StudentRegNumber = Position[6],
             Gender = (Gender)Enum.Parse(typeof(Gender) , Position[7])
            };
            return Profile;
        }

         public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{IsDeleted}\t{FirstName}\t{LastName}\t{DOB}\t{StudentRegNumber}\t{Gender}";
        }
    }
}