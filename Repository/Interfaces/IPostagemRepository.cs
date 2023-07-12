using senac.Models;

namespace senac.Repository.Interfaces
{
    public interface IPostagemRepository
    {
        public bool CriarPostagem(PostagemModel postagem);
        public bool DeletarPostagem(int id);
        public bool ComentarPostagem(ComentarioModel comentario);
        public bool CurtirPostagem(int id, int usuario);
        public bool ApagarComentario(ComentarioModel comentario);
        public IEnumerable<dynamic> LerPostagem(int id);
        public IEnumerable<dynamic> LerPostagemPreview(int? idUsuario);
        public IEnumerable<ComentarioModel> LerComentarios(int id);
        public IEnumerable<CategoriaModel> PegarCategoria();
    }
}