using Microsoft.AspNetCore.Mvc;
using senac.Models;
using senac.Repository.Interfaces;

namespace senac.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository db;
        public UsuarioController(IUsuarioRepository _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                UsuarioModel usuario = db.VerificarUsuario(email, senha);
                return Ok(usuario);
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }
        [HttpGet("user")]
        public IActionResult InformacoesUsuario([FromQuery] string nome)
        {
            try
            {
                UsuarioModel usuario = db.InformacoesUsuario(nome);
                return Ok(usuario);
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }
        [HttpPost]
        public IActionResult CriarUsuario([FromBody] UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!db.EmailValido(usuario.Email))
                    {
                        return BadRequest("E-mail já existente");
                    }

                    if (!db.NomeValido(usuario.Nome))
                    {
                        return BadRequest("Nome já existente");
                    }

                    if (db.CriarUsuario(usuario))
                    {
                        return Ok("Usuário criado");
                    }
                }
                var erros = ModelState.Values.SelectMany(v => v.Errors)
                                                  .Select(e => e.ErrorMessage)
                                                  .ToList();
                foreach (var item in erros)
                {
                    Console.WriteLine(item);
                }
                return BadRequest(erros);
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }
        [HttpPut]
        public IActionResult AlterarUsuario([FromBody] UsuarioModel usuario)
        {

            if (ModelState.IsValid)
            {
                if (db.AlterarUsuario(usuario))
                {
                    return Ok("Usuário alterado");
                }
            }
            var erros = ModelState.Values.SelectMany(v => v.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToList();
            foreach (var item in erros)
            {
                Console.WriteLine(item);
            }
            return BadRequest(erros);

        }
        [HttpDelete]
        public IActionResult DeletarUsuario([FromQuery] int id)
        {
            try
            {
                db.DeletarUsuario(id);
                return Ok("Usuário deletado");
            }
            catch
            {
                return BadRequest("Erro ao processar solicitação");
            }
        }
    }
}