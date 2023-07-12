using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senac.Models
{
    public class PostagemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(4)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(1200)]
        [MinLength(4)]
        public string Conteudo { get; set; }

        [Required]
        [StringLength(25)]
        public string DataCriacao { get; set; }

        public UsuarioModel? Usuario { get; set; }
        public CategoriaModel? Categoria { get; set; }
    }
}
