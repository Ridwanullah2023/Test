using System.Collections.Specialized;

namespace SCHOOL_REGISTER.ENTITY
{
    public class BasicClass : AuditableEntity
    {
        public int Level { get; set; }
        public string Department { get; set; } = default!;

        public static BasicClass ToBasicClass(string sep)
        {
            var Position = sep.Split('\t');
            var BasicClass = new BasicClass()
            {
                Id = int.Parse(Position[0]),
                CreatedAt = DateTime.Parse(Position[1]),
                IsDeleted = bool.Parse(Position[2]),
                Level = int.Parse(Position[3]),
                Department = Position[4],
            };
            return BasicClass;
        }

        public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{IsDeleted}\t{Level}\t{Department}";
        }
    }
}
