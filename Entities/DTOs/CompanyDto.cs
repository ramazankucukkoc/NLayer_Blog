using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CompanyDto : DtoGetBase
    {
        public Company Company { get; set; }
    }
}
