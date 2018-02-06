using System;
using System.Collections.Generic;
using System.Linq;
using Instituicao.Dados;
using Instituicao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instituicao.Controllers
{
    [Route("api/[Controller]")]
    public class CursoController : Controller
    {
        Curso curso = new Curso();
        public JsonResult rs;
        readonly InstituicaoContexto contexto;

        public CursoController(InstituicaoContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Curso> Get()
        {
            return contexto.Curso.ToList();
        }

        [HttpGet("{Id}")]
        public Curso Get(int Id)
        {
            return contexto.Curso.Where(c => c.IdCurso == Id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            contexto.Curso.Add(curso);
            int r = contexto.SaveChanges();
            if (r > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] Curso curso)
        {
            if (curso == null || curso.IdCurso != Id)
            {
                return BadRequest();
            }

            var cli = contexto.Curso.Where(c => c.IdCurso == Id).FirstOrDefault();
            if (cli == null)
            {
                return NotFound();
            }

            cli.IdCurso = curso.IdCurso;
            cli.IdCategoria = curso.IdCategoria;
            cli.Nome = curso.Nome;
            cli.DataInicio = curso.DataInicio;
            cli.DataTermino = curso.DataTermino;
            cli.Semana = curso.Semana;
            cli.HoraInicio = curso.HoraInicio;
            cli.HoraTermino = curso.HoraTermino;
            cli.Categoria = curso.Categoria;

            contexto.Curso.Update(cli);
            int x = contexto.SaveChanges();
            if (x > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var curso = contexto.Curso.Where(c => c.IdCurso == Id).FirstOrDefault();
            if (curso == null)
                return NotFound();

            contexto.Curso.Remove(curso);
            int r = contexto.SaveChanges();
            if (r > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}