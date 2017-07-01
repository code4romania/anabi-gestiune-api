using Microsoft.EntityFrameworkCore;
using Anabi.DataAccess.Ef.DbModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Anabi.DataAccess.Ef.EntityConfigurators
{
    public class StagesForDecisionConfig : IEntityConfig
    {
        public void SetupEntity(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<StagesForDecisionDb>();
            entity.ToTable("StagesForDecisions");

            entity.HasKey(k => k.Id);

            entity.HasOne(u => u.Stage)
                .WithMany(e => e.PossibleDecisions)
                .HasForeignKey(f => f.StageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StagesForDecision_Stage")
                .IsRequired();

            entity.HasOne(d => d.Decision)
                .WithMany(e => e.PossibleStages)
                .HasForeignKey(f => f.DecisionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StagesForDecision_Decision")
                .IsRequired();

            entity.HasIndex(i => new { i.StageId, i.DecisionId }).HasName("indx_Stage_Decision").IsUnique();
        }
    }
}
