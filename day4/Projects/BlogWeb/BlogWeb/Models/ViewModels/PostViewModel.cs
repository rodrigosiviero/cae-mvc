using BlogWeb.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWeb.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Titulo nao Pode ser vazio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Conteudo nao Pode ser vazio")]
        public string Conteudo { get; set; }
        [Required(ErrorMessage = "Data de Publicacao nao pode ser vazia")]
        public DateTime? DataPublicacao { get; set; }
        public Boolean Publicado { get; set; }
        public String Tags { get; set; }

        public Post CriaPost(TagDAO dao)
        {
            Post post = new Post()
            {
                Id = this.Id,
                Titulo = this.Titulo,
                Conteudo = this.Conteudo,
                DataPublicacao = this.DataPublicacao,
                Publicado = this.Publicado
            };
            foreach (string nomeTag in this.Tags.Split(' '))
            {
                Tag tag = dao.BuscaPorNome(nomeTag);
                if (tag == null)
                {
                    tag = new Tag();
                    tag.Nome = nomeTag;
                    dao.Adiciona(tag);
                }
                post.Tags.Add(tag);
            }
            return post;
        }

        public PostViewModel()
        {

        }

        public PostViewModel(Post post)
        {
            this.Id = post.Id;
            this.Titulo = post.Titulo;
            this.Conteudo = post.Conteudo;
            this.DataPublicacao = post.DataPublicacao;
            this.Publicado = post.Publicado;
            this.Tags = String.Join(" ", post.Tags.Select(t => t.Nome));
        }
    }
}