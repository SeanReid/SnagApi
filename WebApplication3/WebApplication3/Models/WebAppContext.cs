using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class WebAppContext : DbContext
    {
        public WebAppContext()
        {
        }

        public WebAppContext(DbContextOptions<WebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobApplicationAnswers> JobApplicationAnswers { get; set; }
        public virtual DbSet<JobApplications> JobApplications { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=WebApp;Integrated Security=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplicationAnswers>(entity =>
            {
                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.JobApplication)
                    .WithMany(p => p.JobApplicationAnswers)
                    .HasForeignKey(d => d.JobApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobApplicationAnswers_JobApplication");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.JobApplicationAnswers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobApplicationAnswers_Question");
            });

            modelBuilder.Entity<JobApplications>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });
        }
    }
}
