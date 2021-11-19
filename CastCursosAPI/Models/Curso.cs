using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastCursosAPI.Models
{
    public class Curso
    {
        public int ID { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataFinal { get; set; }

        [ForeignKey("CategoriaExistente")]
        public int IDCategoria { get; set; }

        [ForeignKey("Usuario")]
        public int IDUsuario { get; set; }
        public List<Log> Log { get; set; }

        #nullable enable
        public int QtdAlunos { get; set; }
    }
}
