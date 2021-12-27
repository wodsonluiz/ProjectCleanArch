using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProjectCleanArch.Application.DTOs
{
    public class CategoryDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
