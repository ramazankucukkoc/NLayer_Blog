using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
    }
}
