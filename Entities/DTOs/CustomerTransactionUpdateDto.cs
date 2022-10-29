namespace Entities.DTOs
{
    public class CustomerTransactionUpdateDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int PersonelId { get; set; }
        //public DateTime MyProperty { get; set; }
        public int Unit { get; set; }//(Adet)
        public int UnitPrice { get; set; }//(Birim fiyat)
        public int TotalPrice { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
