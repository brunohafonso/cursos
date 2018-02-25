using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instituicao.Models
{
    public class Curso
    {
        [Key]
        [Column(Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        
        [Required]
        public int IdCategoria { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength=2)]
        public string Nome { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataTermino { get; set; }
        
        [Required]
        public string Semana { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HoraInicio { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HoraTermino { get; set; }

        public Categoria Categoria { get; set; }

        [Required]
        public string NomeCategoria { get; set; }
        
        internal ICollection<Curso> ToList()
        {
            throw new NotImplementedException();
        }

        public Curso()
        {
            
        }

        public Curso(int IdCategoria, string Nome, DateTime DataInicio, DateTime DataTermino, string Semana, DateTime HoraInicio, DateTime HoraTermino, Categoria Categoria, string NomeCategoria)
        {
            this.IdCategoria = IdCategoria;
            this.Nome = Nome;
            this.DataInicio = DataInicio;
            this.DataTermino = DataTermino;
            this.Semana = Semana;
            this.HoraInicio = HoraInicio;
            this.HoraTermino = HoraTermino;
            this.Categoria = Categoria;
            this.NomeCategoria = NomeCategoria;
        }
    }
}