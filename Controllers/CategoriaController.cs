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
        readonly InstituicaoContexto contexto;

        public CategoriaController(InstituicaoContexto contexto)
        {
            this.contexto = contexto;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return contexto.Categoria.ToList();
        }

        // GET api/values/5
        [HttpGet("{Id}")]
        public Categoria Get(int Id)
        {
            return contexto.Categoria.Where(x => x.IdCategoria == Id).FirstOrDefault();
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


            if (contexto.Categoria.Where(c => c.IdCategoria == Id).FirstOrDefault() == null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            contexto.Categoria.Update(categoria);
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
