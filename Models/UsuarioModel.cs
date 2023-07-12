using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using senac.Data;

namespace senac.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(4)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha corretamente")]
        [StringLength(50)]
        [MinLength(4)]
        public string Senha { get; set; }
        public string? Foto { get; set; }
    }
}