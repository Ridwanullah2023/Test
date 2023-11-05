namespace SCHOOL_REGISTER.ENTITY
{
    public class Guardian : AuditableEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public int AddressId { get; set; } 


         public static Guardian ToGuardian(string sep)
        {
            var Position = sep.Split('\t');
            var Guardian = new Guardian()
            {
             Id = int.Parse(Position[0]),
             CreatedAt = DateTime.Parse(Position[1]),
             IsDeleted = bool.Parse(Position[2]),
             FirstName = Position[3],
             LastName = Position[4],
             PhoneNumber = Position[5],
             AddressId = int.Parse(Position[6])
            
            };
            return Guardian;
        }

         public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{IsDeleted}\t{FirstName}\t{LastName}\t{PhoneNumber}\t{AddressId}";
        }
        
    }
}