using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using senac.Models;

namespace senac.Models
{
    public class GosteiModel
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPostagem { get; set; }

        public UsuarioModel Usuario { get; set; }
        public UsuarioModel Postagem { get; set; }
    }
}