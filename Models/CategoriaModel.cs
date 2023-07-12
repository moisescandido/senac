using System.ComponentModel.DataAnnotations;

namespace senac.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}