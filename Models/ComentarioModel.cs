using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senac.Models
{
    public class ComentarioModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdPostagem { get; set; }

        [Required]
        public int Conteudo { get; set; }
        public PostagemModel Postagem { get; set; }
        public UsuarioModel Usuario { get; set; }

    }
}