﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogWeb.Models;

namespace BlogWeb
{
    public class PostMapping : ClassMap<Post>
    {
        public PostMapping()
        {
            Id(post => post.Id).GeneratedBy.Identity();
            Map(post => post.Titulo);
            Map(post => post.Conteudo);
            Map(post => post.DataPublicacao);
            Map(post => post.Publicado);
        }
    }
}