using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instituicao.Dados;
using Instituicao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instituicao.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        Categoria categoria = new Categoria();
        public JsonResult rs;
        readonly InstituicaoContexto contexto;

        public CategoriaController(InstituicaoContexto contexto)
        {
            this.contexto = contexto;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            var categorias = contexto.Categoria.ToList();
            foreach(var categoria in categorias)
            {
                var cursos = contexto.Curso.Where(x => x.IdCategoria == categoria.IdCategoria).ToList();
                if(cursos == null) 
                {
                    categoria.Curso = null;
                } 
                else 
                {
                    foreach(var curso in cursos)
                    {
                        categoria.Curso.Add(curso);
                    }
                }
            }
            
            return categorias;
        }

        // GET api/values/5
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                var categoria = contexto.Categoria.AsQueryable().Where(x => x.IdCategoria == Id).FirstOrDefault();
                var cursos = contexto.Curso.Where(x => x.IdCategoria == Id).ToList();
                foreach(var item in cursos)
                {
                    categoria.Curso.Add(item);
                }

                rs = new JsonResult(categoria);
                if (categoria == null)
                {
                    rs.ContentType = "application/json";
                    rs.StatusCode = 204;
                    rs.Value = "Não há dados!";
                }
                else
                {
                    rs.ContentType = "application/json";
                    rs.StatusCode = 200;
                }
            }
            catch (Exception e)
            {
                throw new Exception("erro ao buscar dados. " + e.Message);
            }

            return Json(rs);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            contexto.Categoria.Add(categoria);
            int x = contexto.SaveChanges();

            if (x > 0)
                return Ok();
            else
                return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody]Categoria categoria)
        {
            if (categoria == null || categoria.IdCategoria != Id)
            {
                return BadRequest();
            }

            var cli = contexto.Categoria.Where(c => c.IdCategoria == Id).FirstOrDefault();
            if (cli == null)
            {
                return NotFound();
            }


            cli.IdCategoria = categoria.IdCategoria;
            cli.Nome = categoria.Nome;

            contexto.Categoria.Update(cli);
            int x = contexto.SaveChanges();
            if (x > 0)
                return Ok();
            else
                return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var categoria = contexto.Categoria.Where(i => i.IdCategoria == Id).FirstOrDefault();
            if (categoria == null)
                return NotFound();

            contexto.Categoria.Remove(categoria);
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
    }
}
