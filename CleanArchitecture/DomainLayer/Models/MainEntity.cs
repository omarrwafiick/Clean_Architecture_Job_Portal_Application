
using ApplicationLayer.Interfaces;

namespace DomainLayer.Models
{
    public class MainEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
