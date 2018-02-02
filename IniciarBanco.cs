using System;
using System.Linq;
using Instituicao.Dados;
using Instituicao.Models;

namespace Instituicao
{
    public class IniciarBanco
    {
        public static void Inicializar(InstituicaoContexto contexto)
        {
            contexto.Database.EnsureCreated();
            if(contexto.Categoria.Any()) {
                return;
            }

            var categoria = new Categoria("Internet");
            contexto.Categoria.Add(categoria);

            var curso = new Curso(categoria.IdCategoria, "Html e Css", DateTime.Parse("25/02/2018"), DateTime.Parse("28/02/2018"), "segunda-feira,quarta-feira,sexta-feira", DateTime.Parse("20:00"), DateTime.Parse("22:00"), categoria);
            contexto.Curso.Add(curso);

            contexto.SaveChanges();
        }
    }
}