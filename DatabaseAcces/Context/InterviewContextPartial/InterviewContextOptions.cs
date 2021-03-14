using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAcces.Context.InterviewContextPartial
{
    public partial class InterviewContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.HasDbFunction(() => GetNextQuestionId(default));

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasIndex(e => e.QuestionId, "QuestionId");

                entity.Property(e => e.AnswerText).IsRequired();

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Answers_Questions_Surveys_Id");
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.HasIndex(e => e.SurveyId, "SurveyId");

                entity.HasIndex(e => new { e.UserEmail, e.SurveyId }, "UK_Interviews_UserEmail_SurveyId")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserPhone, e.SurveyId }, "UK_Interviews_UserPhone_SurveyId")
                    .IsUnique();

                entity.Property(e => e.PassDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK_Interviews_Suveys_SurveyId");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasIndex(e => e.SurveyId, "SurveyId");

                entity.HasIndex(e => new { e.SurveyId, e.Number }, "UK_Questions_SurveyId_Number")
                    .IsUnique();

                entity.Property(e => e.QuestionText).IsRequired();

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SurveyId);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.AnswerId, "AnswerId");

                entity.HasIndex(e => e.InterviewId, "InterviewId");

                entity.HasOne(d => d.Answer)
                    .WithMany()
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Interview)
                    .WithMany()
                    .HasForeignKey(d => d.InterviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Interview_");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.PublishDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SurveyName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
