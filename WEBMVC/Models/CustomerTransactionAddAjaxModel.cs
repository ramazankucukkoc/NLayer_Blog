using Entities.DTOs;

namespace WEBMVC.Models
{
    public class CustomerTransactionAddAjaxModel
    {
        public CustomerTransactionAddDto CustomerTransactionAddDto { get; set; }
        public string CustomerTransactionAddPartial { get; set; }
        public CustomerTransactionDto CustomerTransactionDto { get; set; }
    }
}
