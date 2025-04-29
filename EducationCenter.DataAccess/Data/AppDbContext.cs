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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Inheritance: Student & Teacher from User
            //modelBuilder.Entity<Student>().HasBaseType<ApplicationUser>();
            //modelBuilder.Entity<Teacher>().HasBaseType<ApplicationUser>();

            // Primary Keys for Join Tables
            modelBuilder.Entity<PrivateLessonTeacher>()
                          .HasKey(x => new { x.TeacherId, x.PrivateLessonID });

            modelBuilder.Entity<PrivateLessonTeacher>()
                .HasOne(pl => pl.Teacher)
                .WithMany() 
                .HasForeignKey(pl => pl.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrivateLessonTeacher>()
                .HasOne(pl => pl.PrivateLesson)
                .WithMany()
                .HasForeignKey(pl => pl.PrivateLessonID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrivateLessonStudent>()
                .HasKey(x => new { x.StudentID, x.PrivateLessonID });

            modelBuilder.Entity<PrivateLessonStudent>()
                .HasOne(ps => ps.Student)
                .WithMany()
                .HasForeignKey(ps => ps.StudentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PrivateLessonStudent>()
                .HasOne(ps => ps.PrivateLesson)
                .WithMany()
                .HasForeignKey(ps => ps.PrivateLessonID)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<TeacherAcademicYear>()
                .HasKey(x => new { x.TeacherId, x.AcademicYearID });

            modelBuilder.Entity<TeacherAcademicYear>()
                .HasOne(ta => ta.Teacher)
                .WithMany()
                .HasForeignKey(ta => ta.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeacherAcademicYear>()
                .HasOne(ta => ta.AcademicYear)
                .WithMany(ay => ay.TeacherAcademicYears)
                .HasForeignKey(ta => ta.AcademicYearID)
                .OnDelete(DeleteBehavior.Restrict);




            modelBuilder.Entity<ClassGroup>()
                .HasOne(cg => cg.Teacher)
                .WithMany()
                .HasForeignKey(cg => cg.TeacherId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade path



            // Student -> AcademicYear (many-to-one)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.AcademicYear)
                .WithMany(ay => ay.Students)
                .HasForeignKey(s => s.AcademicYearID);

            //modelBuilder.Entity<ClassGroup>()
            //    .HasOne(t => t.Teacher)
            //    .WithMany()
            //    .HasForeignKey(t => t.TeacherID);


            // Teacher -> Subject (many-to-one)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Subject)
                .WithMany()
                .HasForeignKey(t => t.SubjectID);

            // Teacher -> AcademicYear (many-to-one)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.AcademicYear)
                .WithMany()
                .HasForeignKey(t => t.AcademicYearID);

            // Enrollment -> ClassGroup & Student
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.ClassGroup)
                .WithMany()
                .HasForeignKey(e => e.ClassGroupID);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentID);

            // Attendance -> Student
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentID)
                .OnDelete(DeleteBehavior.Restrict); // Or .NoAction

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Enrollment)
                .WithMany()
                .HasForeignKey(a => a.EnrollmentID)
                .OnDelete(DeleteBehavior.Restrict); // Prevents multiple cascade paths



            // Payment -> Student & Teacher
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentID);

            //modelBuilder.Entity<Payment>()
            //    .HasOne(p => p.Teacher)
            //    .WithMany()
            //    .HasForeignKey(p => p.TeacherID);


            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);


            // AssessmentResults -> Assessment & Student
            modelBuilder.Entity<AssessmentResult>()
                .HasOne(ar => ar.Assessment)
                .WithMany()
                .HasForeignKey(ar => ar.AssessmentID);

            modelBuilder.Entity<AssessmentResult>()
                .HasOne(ar => ar.Student)
                .WithMany()
                .HasForeignKey(ar => ar.StudentID);

            // NotificationRecipient -> User
            modelBuilder.Entity<NotificationRecipient>()
                .HasOne(nr => nr.User)
                .WithMany()
                .HasForeignKey(nr => nr.UserID)
                .OnDelete(DeleteBehavior.Restrict); // or .NoAction


            // Lecture -> ClassGroup & Assessment & Attendance
            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.ClassGroup)
                .WithMany()
                .HasForeignKey(l => l.ClassGroupID);

            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.Assessment)
                .WithMany()
                .HasForeignKey(l => l.AssessmentID);

            modelBuilder.Entity<Lecture>()
                .HasOne(l => l.Attendance)
                .WithMany()
                .HasForeignKey(l => l.AttendanceID);
        }

    }
}
