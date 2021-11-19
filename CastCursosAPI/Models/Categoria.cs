using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CastCursosAPI.Models
{
    public class Categoria
    {
        [Key]
        public int IDCategoria { get; set; }
        public string CategoriaExiste { get; set; }
    }
}
