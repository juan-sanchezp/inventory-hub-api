// ADD dataAnnotations.
using System.ComponentModel.DataAnnotations;

namespace InventoryHub.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0.01,100000)]
        public float Price { get; set; }

        

    }


    
}
