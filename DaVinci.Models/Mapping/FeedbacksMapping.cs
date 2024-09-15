using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinci.Models.Mapping
{
    public class FeedbacksMapping : IEntityTypeConfiguration<Feedbacks>
    {
        public void Configure(EntityTypeBuilder<Feedbacks> builder)
        {
            builder.ToTable("TB_DV_FEEDBACK");

            builder.HasKey(f => f.IdFeedback);

            builder.Property(f => f.Comentario)
                .HasMaxLength(1000); 
            ;
            builder.Property(f => f.DataFeedback);

            builder.Property(f => f.Avaliacao);

        }
    }
}
