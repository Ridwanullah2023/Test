using System.Security.Cryptography.X509Certificates;

namespace SCHOOL_REGISTER.ENTITY
{
    public class AuditableEntity
    {
        public int Id {get; set;}
        public DateTime CreatedAt {get; set;}
        public bool IsDeleted {get; set;}
    }
}