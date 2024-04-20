using System.ComponentModel.DataAnnotations;

namespace TylorTrubPortfolioBlazor.DTO.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Language { get; set; }

        [Required]
        public string Url { get; set; }
        [Required]
        public string ProjectPhoto { get; set; }

    }
}
