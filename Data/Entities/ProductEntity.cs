using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("products")]
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producent { get; set; }
        public DateTime ProductionDate { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public ISet<ReviewEntity> Reviews { get; set; }
    }
}
