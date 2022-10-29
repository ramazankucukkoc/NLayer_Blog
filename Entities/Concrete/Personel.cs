using Core.Entities;

namespace Entities.Concrete
{
    public class Personel : EntityBase, IEntity
    {
        public string PersonelName { get; set; }
        public string LastName { get; set; }
        public int DepartmanId { get; set; }
        public Departman Departman { get; set; }
        public ICollection<CustomerTransaction> CustomerTransactions { get; set; }
    }
}
