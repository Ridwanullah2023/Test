namespace SCHOOL_REGISTER.ENTITY
{
    public class WeekLayOut : AuditableEntity
    {
        public string StudentRegNumber {get; set;} = default!;
        public string Monday {get; set;} = default!;
        public string Tuesday {get; set;} = default!;
        public string Wednesday {get; set;} = default!;
        public string Thursday {get; set;} = default!;
        public string Friday {get; set;} = default!;



         public static WeekLayOut ToWeekLayOut(string sep)
        {
            var Position = sep.Split('\t');
            var WeekLayOut = new WeekLayOut()
            {
             Id = int.Parse(Position[0]),
             CreatedAt = DateTime.Parse(Position[1]),
             IsDeleted = bool.Parse(Position[2]),
             StudentRegNumber = Position[3],
             Monday = Position[4],
             Tuesday = Position[5],
             Wednesday = Position[6],
             Thursday = Position[7],
             Friday = Position[8]
            };
            return WeekLayOut;
        }

         public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{IsDeleted}\t{StudentRegNumber}\t{Monday}\t{Tuesday}\t{Wednesday}\t{Thursday}\t{Friday}";
        }

    }
}