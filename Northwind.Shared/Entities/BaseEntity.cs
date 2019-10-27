using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
