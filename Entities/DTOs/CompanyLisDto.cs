using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CompanyLisDto : DtoGetBase
    {
        public IList<Company> Companies { get; set; }
    }
}
