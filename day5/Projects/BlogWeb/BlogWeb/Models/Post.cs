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
        public virtual string Titulo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual DateTime? DataPublicacao { get; set; }
        public virtual Boolean Publicado { get; set; } 
        public virtual IList<Tag> Tags {get; set;}
        public virtual Usuario Autor { get; set; }

        public Post()
        {
            this.Tags = new List<Tag>();
        }
    }
}