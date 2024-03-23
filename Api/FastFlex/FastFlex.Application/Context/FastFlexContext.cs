using FastFlex.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFlex.Models.Context
{
    public partial class FastFlexContext : DbContext
    {
        public FastFlexContext()
        {
        }

        public FastFlexContext(DbContextOptions<FastFlexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteDto> Clientes { get; set; } = null!;
        public virtual DbSet<DestinatarioDto> Destinatarios { get; set; } = null!;
        public virtual DbSet<EntregaDto> Entregas { get; set; } = null!;
        public virtual DbSet<EntregadorDto> Entregadors { get; set; } = null!;
        public virtual DbSet<PacoteDto> Pacotes { get; set; } = null!;
        public virtual DbSet<TipoUsuarioDto> TipoUsuarios { get; set; } = null!;
        public virtual DbSet<UsuarioDto> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-81POI2L\\SQLEXPRESS;Database=FastFlex;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteDto>(entity =>
            {
                entity
                 .HasKey(e => e.ClienteId)
                 .HasName("PrimaryKey_ClienteId");

                entity.ToTable("Cliente");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cpnj)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                   .HasMaxLength(15)
                   .IsUnicode(false);

                entity.Property(e => e.Numero)
                 .IsUnicode(false);

                entity.Property(e => e.Telefone)
                 .IsUnicode(false);

                entity.Property(e => e.Descricao)
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.Ativado)
                     .HasDefaultValueSql("1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Cliente__UserId__4316F928");
            });

            modelBuilder.Entity<DestinatarioDto>(entity =>
            {
                entity.ToTable("Destinatario");

                entity
                    .HasKey(e => e.DestinatarioId)
                    .HasName("PrimaryKey_DestinatarioId");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                 .HasMaxLength(15)
                 .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                   .HasMaxLength(15)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<EntregaDto>(entity =>
            {
                entity.ToTable("Entrega");

                entity
                     .HasKey(e => e.EntregaId)
                     .HasName("PrimaryKey_EntregaId");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CepDestino)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CepOrigem)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.HoraEntrega).HasColumnType("datetime");

                entity.Property(e => e.HoraSaida).HasColumnType("datetime");

                entity.Property(e => e.PrecoEntrega).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Rua)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Entrega__Cliente__46E78A0C");

                entity.HasOne(d => d.Destinatario)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.DestinatarioId)
                    .HasConstraintName("FK__Entrega__Destina__47DBAE45");

                entity.HasOne(d => d.Entregador)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.EntregadorId)
                    .HasConstraintName("FK__Entrega__Entrega__45F365D3");
            });

            modelBuilder.Entity<EntregadorDto>(entity =>
            {
                entity.ToTable("Entregador");

                entity
                    .HasKey(e => e.EntregadorId)
                    .HasName("PrimaryKey_EntregadorId");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Mei)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("MEI");

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                  .HasMaxLength(15)
                  .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Entregadors)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Entregado__UserI__403A8C7D");
            });

            modelBuilder.Entity<PacoteDto>(entity =>
            {
                entity.ToTable("Pacote");

                entity
                     .HasKey(e => e.PacoteId)
                     .HasName("PrimaryKey_PacoteId");

                entity.Property(e => e.Altura).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Comprimento).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Largura).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ValorDeclarado).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Entrega)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.EntregaId)
                    .HasConstraintName("FK__Pacote__EntregaI__4AB81AF0");
            });

            modelBuilder.Entity<TipoUsuarioDto>(entity =>
            {
                entity.ToTable("TipoUsuario");

                modelBuilder.Entity<TipoUsuarioDto>()
                 .HasKey(e => e.TipoUsuarioId)
                 .HasName("PrimaryKey_TipoUsuarioId");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioDto>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Usuario__1788CC4CCD0F6636");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ativado)
                     .HasDefaultValueSql("1");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .HasConstraintName("FK__Usuario__TipoUsu__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}