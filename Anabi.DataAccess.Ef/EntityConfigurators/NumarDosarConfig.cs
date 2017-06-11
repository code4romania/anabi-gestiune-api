using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class NumarDosarConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<NumarDosarDb>();
            entity.ToTable("NumereDosare");

            entity.HasKey(k => k.Id);

            entity.Property(p => p.NrDosar)
                .HasMaxLength(50)
                .IsRequired();

           
            entity.HasOne(i => i.Institutie)
                .WithMany(d => d.NumereDosare)
                .HasForeignKey(k => k.InstitutieId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_NumereDosare_Institutii")
                .IsRequired();

            entity.Property(p => p.DataNumarului)
                .HasColumnType("Datetime")
                .IsRequired();

            entity.Property(p => p.CodUtilizatorAdaugare)
               .HasMaxLength(20)
               .IsRequired();

            entity.Property(p => p.CodUtilizatorUltimaModificare)
                .HasMaxLength(20);

            entity.Property(p => p.DataAdaugare)
                .HasColumnType("DateTime")
                .IsRequired();

            entity.Property(p => p.DataUltimeiModificari)
                .HasColumnType("Datetime");



        }
    }
}
