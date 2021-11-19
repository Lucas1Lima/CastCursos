using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CastCursosAPI.Models
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Adm { get; set; }
    }
}
