using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Session2.Domains;

#nullable disable

namespace Session2.Contexts
{
    public partial class Session2Context : DbContext
    {
        public Session2Context()
        {
        }

        public Session2Context(DbContextOptions<Session2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Estoque> Estoques { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }
        public virtual DbSet<Participante> Participantes { get; set; }
        public virtual DbSet<ParticipantesEvento> ParticipantesEventos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Regiao> Regiaos { get; set; }
        public virtual DbSet<TipoEvento> TipoEventos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<VwProduto> VwProdutos { get; set; }
        public virtual DbSet<VwRank> VwRanks { get; set; }
        public virtual DbSet<VwRegiao> VwRegiaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost; initial catalog=Session2; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("cidade");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cidade1)
                    .HasMaxLength(255)
                    .HasColumnName("Cidade");

                entity.Property(e => e.EstadoId).HasColumnName("estadoId");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK_cidade_estado");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado1)
                    .HasMaxLength(255)
                    .HasColumnName("Estado");

                entity.Property(e => e.Sigla).HasMaxLength(255);

                entity.HasOne(d => d.Regiao)
                    .WithMany(p => p.Estados)
                    .HasForeignKey(d => d.RegiaoId)
                    .HasConstraintName("FK_estado_regiao");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.ToTable("estoque");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LojaId).HasColumnName("lojaId");

                entity.Property(e => e.ProdutoId).HasColumnName("produtoId");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.Loja)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.LojaId)
                    .HasConstraintName("FK_estoque_loja");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_estoque_produto");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("evento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Evento1)
                    .HasMaxLength(255)
                    .HasColumnName("evento");

                entity.Property(e => e.TipoEventoId).HasColumnName("tipoEventoId");

                entity.HasOne(d => d.TipoEvento)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.TipoEventoId)
                    .HasConstraintName("FK_evento_tipo_evento");
            });

            modelBuilder.Entity<Loja>(entity =>
            {
                entity.ToTable("loja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Loja1)
                    .HasMaxLength(255)
                    .HasColumnName("loja");
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.ToTable("participante");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CidadeId).HasColumnName("cidadeId");

                entity.Property(e => e.Genero)
                    .HasMaxLength(255)
                    .HasColumnName("genero");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Participantes)
                    .HasForeignKey(d => d.CidadeId)
                    .HasConstraintName("FK_participante_cidade");
            });

            modelBuilder.Entity<ParticipantesEvento>(entity =>
            {
                entity.ToTable("participantes_evento");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventoId).HasColumnName("eventoId");

                entity.Property(e => e.ParticipanteId).HasColumnName("participanteId");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.ParticipantesEventos)
                    .HasForeignKey(d => d.EventoId)
                    .HasConstraintName("FK_participantes_evento_evento");

                entity.HasOne(d => d.Participante)
                    .WithMany(p => p.ParticipantesEventos)
                    .HasForeignKey(d => d.ParticipanteId)
                    .HasConstraintName("FK_participantes_evento_participante");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Produto1)
                    .HasMaxLength(255)
                    .HasColumnName("produto");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.ToTable("regiao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Regiao1)
                    .HasMaxLength(255)
                    .HasColumnName("regiao");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.ToTable("tipo_evento");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Tipoevento1)
                    .HasMaxLength(255)
                    .HasColumnName("tipoevento");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.ToTable("vendas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.EventoId).HasColumnName("eventoId");

                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .HasColumnName("hora");

                entity.Property(e => e.LojaId).HasColumnName("lojaId");

                entity.Property(e => e.ParticipanteId).HasColumnName("participanteId");

                entity.Property(e => e.ProdutoId).HasColumnName("produtoId");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Transação).HasColumnName("transação");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.EventoId)
                    .HasConstraintName("FK_vendas_evento");

                entity.HasOne(d => d.Loja)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.LojaId)
                    .HasConstraintName("FK_vendas_loja");

                entity.HasOne(d => d.Participante)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.ParticipanteId)
                    .HasConstraintName("FK_vendas_participante");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_vendas_produto");
            });

            modelBuilder.Entity<VwProduto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Produto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Produto)
                    .HasMaxLength(255)
                    .HasColumnName("produto");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<VwRank>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Rank");

                entity.Property(e => e.Cidade).HasMaxLength(255);

                entity.Property(e => e.Estado).HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.Property(e => e.Pontos).HasColumnName("pontos");

                entity.Property(e => e.Sigla).HasMaxLength(255);
            });

            modelBuilder.Entity<VwRegiao>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Regiao");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Regiao)
                    .HasMaxLength(255)
                    .HasColumnName("regiao");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Vendas).HasColumnName("vendas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
