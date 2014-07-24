using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    class PostMapping : ClassMap<Post>
    {
        public PostMapping()
        {
            //Table("posts");
            Id(post => post.Id).GeneratedBy.Identity();
            Map(post => post.Titulo);
            Map(post => post.Conteudo);
            Map(post => post.DataPublicacao);
            Map(post => post.Publicado);
        }
    }
}
