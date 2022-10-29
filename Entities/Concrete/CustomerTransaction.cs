using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerTransaction : EntityBase, IEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int PersonelId { get; set; }
        //public DateTime MyProperty { get; set; }
        public int Unit { get; set; }//(Adet)
        public int UnitPrice { get; set; }//(Birim fiyat)
        public int TotalPrice { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Personel Personel { get; set; }

    }
}
