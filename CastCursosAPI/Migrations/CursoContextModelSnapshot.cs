﻿// <auto-generated />
using System;
using CastCursosAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CastCursosAPI.Migrations
{
    [DbContext(typeof(CursoContext))]
    partial class CursoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CastCursosAPI.Models.Categoria", b =>
                {
                    b.Property<int>("IDCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoriaExiste")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CastCursosAPI.Models.Curso", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<int>("QtdAlunos")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("CastCursosAPI.Models.Log", b =>
                {
                    b.Property<int>("IDLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDCurso")
                        .HasColumnType("int");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("IDLog");

                    b.HasIndex("CursoID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("CastCursosAPI.Models.Usuario", b =>
                {
                    b.Property<int>("IDUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adm")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CastCursosAPI.Models.Log", b =>
                {
                    b.HasOne("CastCursosAPI.Models.Curso", null)
                        .WithMany("Log")
                        .HasForeignKey("CursoID");
                });

            modelBuilder.Entity("CastCursosAPI.Models.Curso", b =>
                {
                    b.Navigation("Log");
                });
#pragma warning restore 612, 618
        }
    }
}
