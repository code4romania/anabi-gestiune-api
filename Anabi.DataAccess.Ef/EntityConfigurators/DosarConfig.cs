using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class DosarConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<DosarDb>();
            entity.ToTable("Dosare");

            entity.HasKey(k => k.Id);


            //entity.HasOne(nrd => nrd.NumarInitial)
            //    .WithMany(n => n.DosareInitial)
            //    .HasForeignKey(k => k.NumarDosarInitialId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .HasConstraintName("FK_Dosare_NumarInitial")
            //    .IsRequired();

            //entity.HasOne(n => n.NumarCurent)
            //    .WithMany(n => n.DosareCurent)
            //    .HasForeignKey(k => k.NumarDosarCurentId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .HasConstraintName("FK_Dosare_NumarCurent")
            //    .IsRequired();

            //entity.HasOne(nrd => nrd.NumarInitial)
            //    .WithOne(n => n.DosarInitial)
            //    .HasForeignKey<DosarDb>(k => k.NumarDosarInitialId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .HasConstraintName("FK_Dosare_NumarInitial")
            //    .IsRequired();            

            //entity.HasOne(n => n.NumarCurent)
            //    .WithOne(n => n.DosarCurent)
            //    .HasForeignKey<DosarDb>(k => k.NumarDosarCurentId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .HasConstraintName("FK_Dosare_NumarCurent")
            //    .IsRequired();

            entity.Property(x => x.NumarDosarInitial)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.NumarDosarCurent)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.Prejudiciu)
                .IsRequired();
            entity.Property(p => p.ValutaPrejudiciu)
                .IsRequired();
            entity.Property(p => p.IncadrareJuridica)
                .IsRequired();
            entity.Property(p => p.DomeniuInfractional)
                .IsRequired();

            entity.Property(p => p.CodUtilizatorAdaugare)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.CodUtilizatorUltimaModificare)
                .HasMaxLength(20);


            entity.HasOne(u => u.UtilizatorAdaugare)
                .WithMany(nd => nd.DosareAdaugare)
                .HasForeignKey(k => k.CodUtilizatorAdaugare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Dosare_Utilizator_Adaugare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);

            entity.HasOne(u => u.UtilizatorUltimaModificare)
                .WithMany(nd => nd.DosareModificare)
                .HasForeignKey(k => k.CodUtilizatorUltimaModificare)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Dosare_Utilizator_Modificare")
                .HasPrincipalKey(k2 => k2.CodUtilizator);

            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");

        }
    }
}
