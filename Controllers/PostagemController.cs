using Microsoft.AspNetCore.Mvc;
using senac.Models;
using senac.Repository.Interfaces;

namespace senac.Controllers
{
    [ApiController]
    [Route("api/postagem")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemRepository db;
        public PostagemController(IPostagemRepository _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult CriarPostagem([FromBody] PostagemModel postagem)
        {
            bool resultado = db.CriarPostagem(postagem);

            if (resultado)
            {
                return Ok("Postagem criada");
            }

            return BadRequest("Erro ao processar solicitação");
        }
        [HttpDelete]
        public IActionResult DeletarPostagem([FromQuery] int id)
        {
            bool resultado = db.DeletarPostagem(id);

            if (resultado)
            {
                return Ok("Postagem deletada");
            }

            return BadRequest("Erro ao processar solicitação");
        }

        [HttpGet]
        public IActionResult LerPostagem([FromQuery] int id)
        {
            try
            {

                IEnumerable<dynamic> postagem = db.LerPostagem(id);

                if (postagem is null)
                {
                    return NotFound("Postagem não encontrada");
                }

                return Ok(postagem);
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }

        [HttpGet("post")]
        public IActionResult LerPostagemPreview(int? id)
        {
            try
            {
                IEnumerable<dynamic> postagem = db.LerPostagemPreview(id);

                if (postagem is null)
                {
                    return NotFound("Postagem não encontrada");
                }
                return Ok(postagem);
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }
        [HttpPost("curtir")]
        public IActionResult CurtirPostagem([FromQuery] int id, int usuario)
        {
            id = 3;
            usuario = 3;
            try
            {
                bool resultado = db.CurtirPostagem(id, usuario);

                if (resultado)
                {
                    return Ok("Postagem curtida");
                }
                return Ok("Postagem descurtida");
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }
        [HttpGet("comentario")]
        public IActionResult LerComentarios(int id)
        {
            try
            {
                IEnumerable<ComentarioModel> comentarios = db.LerComentarios(id);
                return Ok(comentarios);
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }
        [HttpDelete("comentario")]
        public IActionResult ApagarComentario(ComentarioModel comentario)
        {
            try
            {
                bool resultado = db.ApagarComentario(comentario);
                return Ok("Comentário deletado");
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");

            }
        }
        [HttpPost("comentario")]
        public IActionResult ComentarPostagem(ComentarioModel comentario)
        {
            bool resultado = db.ComentarPostagem(comentario);

            if (resultado)
            {
                return Ok("Comentário feito com sucesso");
            }
            return BadRequest("Erro ao processar solicitação");
        }
        [HttpGet("categorias")]
        public IActionResult PegarCategorias()
        {
            IEnumerable<CategoriaModel> categorias = db.PegarCategoria();

            if (categorias == null)
            {
                return NotFound("Nada encontrado");
            }
            return Ok(categorias);
        }
    }
}