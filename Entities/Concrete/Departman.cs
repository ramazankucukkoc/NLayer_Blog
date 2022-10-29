using Core.Entities;

namespace Entities.Concrete
{
    public class Departman : EntityBase, IEntity
    {
        public string DepartmanName { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}
