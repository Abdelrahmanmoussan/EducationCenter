using EducationCenter.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace EducationCenter.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<PrivateLesson> PrivateLessons { get; set; }
        public DbSet<PrivateLessonTeacher> PrivateLessonTeachers { get; set; }
        public DbSet<PrivateLessonStudent> PrivateLessonStudents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectAcademicYear> SubjectAcademicYears { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssessmentResult> AssessmentResults { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<TeacherAcademicYear> TeacherAcademicYears { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationRecipient> NotificationRecipients { get; set; }
        public DbSet<Lecture> Lectures { get; set; }


        // Inheritance: Student & Teacher from User
        //modelBuilder.Entity<Student>().HasBaseType<ApplicationUser>();
        //modelBuilder.Entity<Teacher>().HasBaseType<ApplicationUser>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>()
                .HasOne(s => s.ApplicationUser)
                .WithOne()
                .HasForeignKey<Student>(s => s.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== PrivateLessonTeacher =====
            modelBuilder.Entity<PrivateLessonTeacher>()
                .HasKey(x => new { x.TeacherId, x.PrivateLessonID });

            modelBuilder.Entity<PrivateLessonTeacher>()
                .HasOne(pl => pl.Teacher)
                .WithMany(t => t.PrivateLessonTeachers)
                .HasForeignKey(pl => pl.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrivateLessonTeacher>()
                .HasOne(pl => pl.PrivateLesson)
                .WithMany(pl => pl.PrivateLessonTeachers)
                .HasForeignKey(pl => pl.PrivateLessonID)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== PrivateLessonStudent =====
            modelBuilder.Entity<PrivateLessonStudent>()
                .HasKey(x => new { x.Id, x.PrivateLessonID });

            modelBuilder.Entity<PrivateLessonStudent>()
                .HasOne(ps => ps.Student)
                .WithMany(s => s.PrivateLessonStudents)
                .HasForeignKey(ps => ps.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrivateLessonStudent>()
                .HasOne(ps => ps.PrivateLesson)
                .WithMany(pl => pl.PrivateLessonStudents)
                .HasForeignKey(ps => ps.PrivateLessonID)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== SubjectAcademicYear =====
            modelBuilder.Entity<SubjectAcademicYear>()
                .HasKey(x => new { x.SubjectID, x.AcademicYearID });

            modelBuilder.Entity<SubjectAcademicYear>()
                .HasOne(say => say.Subject)
                .WithMany(s => s.SubjectAcademicYears)
                .HasForeignKey(say => say.SubjectID);

            modelBuilder.Entity<SubjectAcademicYear>()
                .HasOne(say => say.AcademicYear)
                .WithMany(ay => ay.SubjectAcademicYears)
                .HasForeignKey(say => say.AcademicYearID);

            // ===== TeacherAcademicYear =====
            modelBuilder.Entity<TeacherAcademicYear>()
                .HasKey(x => new { x.TeacherId, x.AcademicYearID });

            modelBuilder.Entity<TeacherAcademicYear>()
                .HasOne(ta => ta.Teacher)
                .WithMany(t => t.TeacherAcademicYears)
                .HasForeignKey(ta => ta.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherAcademicYear>()
                .HasOne(ta => ta.AcademicYear)
                .WithMany(ay => ay.TeacherAcademicYears)
                .HasForeignKey(ta => ta.AcademicYearID)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== ClassGroup =====
            modelBuilder.Entity<ClassGroup>()
                .HasOne(cg => cg.Teacher)
                .WithMany(t => t.ClassGroups)
                .HasForeignKey(cg => cg.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== Student =====
            modelBuilder.Entity<Student>()
                .HasOne(s => s.AcademicYear)
                .WithMany(ay => ay.Students)
                .HasForeignKey(s => s.AcademicYearID);

            // ===== Teacher =====
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Subject)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SubjectID);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.AcademicYear)
                .WithMany(ay => ay.Teachers)
                .HasForeignKey(t => t.AcademicYearID);

            // ===== Enrollment =====
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.ClassGroup)
                .WithMany(cg => cg.Enrollments)
                .HasForeignKey(e => e.ClassGroupID);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.Id);

            // ===== Attendance =====
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Enrollment)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EnrollmentID)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== Payment =====
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.Id);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Teacher)
                .WithMany(t => t.Payments)
                .HasForeignKey(p => p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== AssessmentResult =====
            modelBuilder.Entity<AssessmentResult>()
                .HasOne(ar => ar.Assessment)
                .WithMany(a => a.AssessmentResults)
                .HasForeignKey(ar => ar.AssessmentID);

            modelBuilder.Entity<AssessmentResult>()
                .HasOne(ar => ar.Student)
                .WithMany(s => s.AssessmentResults)
                .HasForeignKey(ar => ar.Id);

            // ===== Lecture =====
            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.ClassGroup)
                .WithMany(cg => cg.Lectures)
                .HasForeignKey(l => l.ClassGroupID);

            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.Assessment)
                .WithMany(a => a.Lectures)
                .HasForeignKey(l => l.AssessmentID);

            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.Attendance)
                .WithMany(a => a.Lectures)
                .HasForeignKey(l => l.AttendanceID);
        }


    }
}
