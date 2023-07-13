using senac.Data;
using senac.Models;
using senac.Repository.Interfaces;

namespace senac.Repository
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly ForumDbContext db;
        public PostagemRepository(ForumDbContext _db)
        {
            db = _db;
        }
        public bool ApagarComentario(ComentarioModel comentario)
        {
            try
            {
                db.Comentario.Remove(comentario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ComentarPostagem(ComentarioModel comentario)
        {
            try
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CriarPostagem(PostagemModel postagem)
        {
            try
            {
                db.Postagem.Add(postagem);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CurtirPostagem(int id, int usuario)
        {
            bool usuarioCurtiu = db.Gostei.Any(x => x.IdPostagem == id && x.IdUsuario == usuario);

            if (usuarioCurtiu)
            {
                GosteiModel gostei = db.Gostei.FirstOrDefault(x => x.IdPostagem == id && x.IdUsuario == usuario);
                db.Gostei.Remove(gostei);
                db.SaveChanges();

                return false; // Usuário descurtiu publicação
            }

            GosteiModel gostei1 = new GosteiModel
            {
                IdPostagem = id,
                IdUsuario = usuario
            };

            db.Gostei.Add(gostei1);
            db.SaveChanges();
            return true; // Usuário curtiu publicação
        }

        public bool DeletarPostagem(int id)
        {
            try
            {
                PostagemModel postagem = db.Postagem.FirstOrDefault(x => x.Id == id);
                db.Postagem.Remove(postagem);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<ComentarioModel> LerComentarios(int id)
        {
            try
            {
                return db.Comentario.Where(x => x.IdPostagem == id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<dynamic> LerPostagem(int id)
        {
            try
            {
                return from postagem in db.Postagem
                       join usuario in db.Usuario on postagem.IdUsuario equals usuario.Id
                       join categoria in db.Categoria on postagem.IdCategoria equals categoria.Id
                       where postagem.Id == id
                       select new
                       {
                           IdPostagem = postagem.Id,
                           IdUsuario = postagem.IdUsuario,
                           IdCategoria = postagem.IdCategoria,
                           Categoria = categoria.Nome,
                           Usuario = usuario.Nome,
                           Titulo = postagem.Titulo,
                           Conteudo = postagem.Conteudo,
                           DataCriacao = postagem.DataCriacao
                       };
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<dynamic> LerPostagemPreview(int? id)
        {
            try
            {
                if (id == null)
                {
                    return from postagem in db.Postagem
                           join usuario in db.Usuario on postagem.IdUsuario equals usuario.Id
                           join categoria in db.Categoria on postagem.IdCategoria equals categoria.Id
                           orderby postagem.DataCriacao descending
                           select new
                           {
                               IdPostagem = postagem.Id,
                               IdUsuario = postagem.IdUsuario,
                               IdCategoria = postagem.IdCategoria,
                               Categoria = categoria.Nome,
                               Usuario = usuario.Nome,
                               Titulo = postagem.Titulo,
                               Conteudo = postagem.Conteudo,
                               DataCriacao = postagem.DataCriacao
                           };
                }
                else
                {
                    return from postagem in db.Postagem
                           join usuario in db.Usuario on postagem.IdUsuario equals usuario.Id
                           join categoria in db.Categoria on postagem.IdCategoria equals categoria.Id
                           where usuario.Id == id
                           orderby postagem.DataCriacao descending
                           select new
                           {
                               IdPostagem = postagem.Id,
                               IdUsuario = postagem.IdUsuario,
                               IdCategoria = postagem.IdCategoria,
                               Categoria = categoria.Nome,
                               Usuario = usuario.Nome,
                               Titulo = postagem.Titulo,
                               Conteudo = postagem.Conteudo,
                               DataCriacao = postagem.DataCriacao
                           };
                }
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CategoriaModel> PegarCategoria()
        {
            try
            {
                return db.Categoria.ToList().AsEnumerable();
            }
            catch
            {
                return null;
            }
        }
    }
}