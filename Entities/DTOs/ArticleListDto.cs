using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
