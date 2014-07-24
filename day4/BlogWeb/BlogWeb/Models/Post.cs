using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage="Titulo nao Pode ser vazio")]
        public virtual string Titulo { get; set; }
        [Required(ErrorMessage = "Conteudo nao Pode ser vazio")]
        public virtual string Conteudo { get; set; }
        [Required(ErrorMessage = "Data de Publicacao nao pode ser vazia")]
        public virtual DateTime? DataPublicacao { get; set; }
        public virtual Boolean Publicado { get; set; }        
    }
}