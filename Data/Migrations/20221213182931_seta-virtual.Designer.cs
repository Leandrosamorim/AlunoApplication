﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AlunoContext))]
    [Migration("20221213182931_seta-virtual")]
    partial class setavirtual
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.AlunoNS.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Domain.Models.AtrasoNS.Atraso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("JustificativaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("JustificativaId");

                    b.ToTable("Atraso");
                });

            modelBuilder.Entity("Domain.Models.AvaliacaoNS.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Domain.Models.EntregaNS.Entrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int?>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<string>("BlobUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("AvaliacaoId");

                    b.HasIndex("TarefaId");

                    b.ToTable("Entrega");
                });

            modelBuilder.Entity("Domain.Models.FaltaNS.Falta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("JustificativaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("JustificativaId");

                    b.ToTable("Falta");
                });

            modelBuilder.Entity("Domain.Models.JustificativaNS.Justificativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Justificativa");
                });

            modelBuilder.Entity("Domain.Models.ProfessorNS.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Domain.Models.TarefaNS.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("Domain.Models.TurmaNS.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Domain.Models.AlunoNS.Aluno", b =>
                {
                    b.HasOne("Domain.Models.TurmaNS.Turma", null)
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.AtrasoNS.Atraso", b =>
                {
                    b.HasOne("Domain.Models.AlunoNS.Aluno", null)
                        .WithMany("Atrasos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JustificativaNS.Justificativa", "Justificativa")
                        .WithMany()
                        .HasForeignKey("JustificativaId");

                    b.Navigation("Justificativa");
                });

            modelBuilder.Entity("Domain.Models.EntregaNS.Entrega", b =>
                {
                    b.HasOne("Domain.Models.AlunoNS.Aluno", null)
                        .WithMany("Entregas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.AvaliacaoNS.Avaliacao", "Avaliacao")
                        .WithMany()
                        .HasForeignKey("AvaliacaoId");

                    b.HasOne("Domain.Models.TarefaNS.Tarefa", null)
                        .WithMany("Entrega")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliacao");
                });

            modelBuilder.Entity("Domain.Models.FaltaNS.Falta", b =>
                {
                    b.HasOne("Domain.Models.AlunoNS.Aluno", null)
                        .WithMany("Faltas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.JustificativaNS.Justificativa", "Justificativa")
                        .WithMany()
                        .HasForeignKey("JustificativaId");

                    b.Navigation("Justificativa");
                });

            modelBuilder.Entity("Domain.Models.TarefaNS.Tarefa", b =>
                {
                    b.HasOne("Domain.Models.TurmaNS.Turma", null)
                        .WithMany("Tarefas")
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("Domain.Models.TurmaNS.Turma", b =>
                {
                    b.HasOne("Domain.Models.ProfessorNS.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Domain.Models.AlunoNS.Aluno", b =>
                {
                    b.Navigation("Atrasos");

                    b.Navigation("Entregas");

                    b.Navigation("Faltas");
                });

            modelBuilder.Entity("Domain.Models.TarefaNS.Tarefa", b =>
                {
                    b.Navigation("Entrega");
                });

            modelBuilder.Entity("Domain.Models.TurmaNS.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}