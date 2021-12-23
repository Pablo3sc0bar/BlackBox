using System.ComponentModel.DataAnnotations;

namespace BlackBox.Entities.ProductAdditionals
{
    public class Jenre
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
