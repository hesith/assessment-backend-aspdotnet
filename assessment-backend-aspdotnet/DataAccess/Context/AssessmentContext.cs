using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using assessment_backend_aspdotnet.DataAccess.Entities;

namespace assessment_backend_aspdotnet.DataAccess.Context;

public partial class AssessmentContext : DbContext
{
    public AssessmentContext()
    {
    }

    public AssessmentContext(DbContextOptions<AssessmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=assessment;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("class");

            entity.Property(e => e.Id)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Grade)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("grade");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("enrollment");

            entity.Property(e => e.Id)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.StudentId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("student_id");
            entity.Property(e => e.SubjectId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("subject_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_enrollment_student");

            entity.HasOne(d => d.Subject).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_enrollment_subject");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("student");

            entity.Property(e => e.Id)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Age)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("age");
            entity.Property(e => e.ClassId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("class_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_student_class")
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("subject");

            entity.Property(e => e.Id)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Teacher)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("teacher");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
