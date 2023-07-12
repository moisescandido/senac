using senac.Models;

namespace senac.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        public bool CriarUsuario(UsuarioModel usuario);
        public UsuarioModel VerificarUsuario(string email, string senha);
        public UsuarioModel InformacoesUsuario(string nome);
        public bool AlterarUsuario(UsuarioModel usuario);
        public bool DeletarUsuario(int id);
        public bool EmailValido(string email);
        public bool NomeValido(string nome);
    }
}