using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CastCursosAPI.Models
{
    public class Log
    {
        [Key]
        public int IDLog { get; set; }
        enum Acao
        {
            DataInclusao,
            DataAtualizacao,
            Remocao
        }
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey("Usuario")]
        public int IDUsuario { get; set; }
        [ForeignKey("Curso")]
        public int IDCurso { get; set; }
    }
}
