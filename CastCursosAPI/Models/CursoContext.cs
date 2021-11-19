using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastCursosAPI.Models
{
    public class CursoContext : DbContext
    {
        public CursoContext(DbContextOptions<CursoContext> options) : base(options)
        { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
