﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nyous.Domains;

namespace Nyous.Contexts
{
    public partial class NyousContext : DbContext
    {
        public NyousContext()
        {
        }

        public NyousContext(DbContextOptions<NyousContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acesso> Acesso { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Convite> Convite { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Localizacao> Localizacao { get; set; }
        public virtual DbSet<Presenca> Presenca { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=LAB107401\\SQLEXPRESS;Initial Catalog=Nyous;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acesso>(entity =>
            {
                entity.HasKey(e => e.IdAcesso)
                    .HasName("PK__Acesso__CDF01DA121D20DD3");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A10C07119D8");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Convite>(entity =>
            {
                entity.HasKey(e => e.IdConvite)
                    .HasName("PK__Convite__318FC5544A886B57");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Convite)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Convite__IdEvent__47DBAE45");

                entity.HasOne(d => d.IdUsuarioConvidadoNavigation)
                    .WithMany(p => p.ConviteIdUsuarioConvidadoNavigation)
                    .HasForeignKey(d => d.IdUsuarioConvidado)
                    .HasConstraintName("FK__Convite__IdUsuar__49C3F6B7");

                entity.HasOne(d => d.IdUsuarioEmissorNavigation)
                    .WithMany(p => p.ConviteIdUsuarioEmissorNavigation)
                    .HasForeignKey(d => d.IdUsuarioEmissor)
                    .HasConstraintName("FK__Convite__IdUsuar__48CFD27E");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__Evento__034EFC047EF5950A");

                entity.Property(e => e.AcessoRestrito)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DataEvento).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Evento__IdCatego__412EB0B6");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .HasConstraintName("FK__Evento__IdLocali__403A8C7D");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.HasKey(e => e.IdLocalizacao)
                    .HasName("PK__Localiza__C96A5BF65B48BF5A");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__Presenca__50FB6F5D440F83A9");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Presenca)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Presenca__IdEven__440B1D61");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Presenca)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Presenca__IdUsua__44FF419A");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97D790A5C4");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAcessoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdAcesso)
                    .HasConstraintName("FK__Usuario__IdAcess__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
