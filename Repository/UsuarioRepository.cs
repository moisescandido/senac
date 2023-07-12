using senac.Data;
using senac.Models;
using senac.Repository.Interfaces;

namespace senac.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ForumDbContext db;
        public UsuarioRepository(ForumDbContext _db)
        {
            db = _db;
        }

        public bool AlterarUsuario(UsuarioModel usuario)
        {

            try
            {
                db.Usuario.Update(usuario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CriarUsuario(UsuarioModel usuario)
        {
            try
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletarUsuario(int id)
        {
            try
            {
                UsuarioModel usuario = db.Usuario.FirstOrDefault(x => x.Id == id);
                db.Usuario.Remove(usuario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EmailValido(string email)
        {
            try
            {
                int quantidade = db.Usuario.Count(x => x.Email == email);

                if (quantidade > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UsuarioModel InformacoesUsuario(string nome)
        {
            try
            {
                UsuarioModel? usuario = db.Usuario.FirstOrDefault(x => x.Nome == nome);
                return usuario;
            }
            catch
            {
                return null;
            }
        }

        public bool NomeValido(string nome)
        {
            try
            {
                int quantidade = db.Usuario.Count(x => x.Nome == nome);
                if (quantidade > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UsuarioModel VerificarUsuario(string email, string senha)
        {
            try
            {
                UsuarioModel? usuario = db.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha);
                return usuario;
            }
            catch
            {
                return null;
            }
        }
    }
}