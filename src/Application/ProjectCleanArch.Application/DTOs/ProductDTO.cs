using Newtonsoft.Json;
using ProjectCleanArch.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCleanArch.Application.DTOs
{
    public class ProductDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        
        [JsonProperty("name")]
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonProperty("description")]
        [Required(ErrorMessage = "The Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        [JsonProperty("price")]
        [Required(ErrorMessage = "The Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [JsonProperty("stock")]
        [Required(ErrorMessage = "The Stock is required")]
        [Range(1, 9999)]
        public int Stock { get; set; }

        [JsonProperty("image")]
        [MaxLength(255)]
        public string Image { get; set; }

        public int CategoryId { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }
    }
}
