using Core.Entities;

namespace Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
