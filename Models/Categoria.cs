using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instituicao.Models
{
    public class Categoria
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength=2)]
        public string Nome { get; set; }

        public ICollection<Curso> Curso { get; set; }
        
        public Categoria()
        {
            
        }

        public Categoria(string Nome)
        {
            this.Nome = Nome;
        }
    }
}