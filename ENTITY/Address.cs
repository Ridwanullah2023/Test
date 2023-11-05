namespace SCHOOL_REGISTER.ENTITY
{
    public class Address : AuditableEntity
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;


        public static Address ToAddress(string sep)
        {
            var Position = sep.Split('\t');
            var Address = new Address()
            {
             Id = int.Parse(Position[0]),
             CreatedAt = DateTime.Parse(Position[1]),
             IsDeleted = bool.Parse(Position[2]),
             HouseNumber = int.Parse(Position[3]),
             StreetName = Position[4],
             City = Position[5],
             State = Position[6],
            };
            return Address;
        }

         public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{IsDeleted}\t{HouseNumber}\t{StreetName}\t{City}\t{State}";
        }

    }
}