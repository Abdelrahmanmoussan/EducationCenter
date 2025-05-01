using EducationCenter.DataAccess.Data;
using EducationCenter.DataAccess.Repository.IRepository;
using EducationCenter.Models.DTOs.Request;
using EducationCenter.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AppDbContext dbContext;

        public StudentRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            dbContext = appDbContext;
        }
        public async Task<Student> CreateStudentAsync(StudentRequest studentRequest, string userId)
        {
            var student = new Student
            {
                ApplicationUserId = userId,
                //AcademicYearID = studentRequest.AcademicYearID,
                ParentName = studentRequest.ParentName,
                ParentPhone = studentRequest.ParentPhone,
                ParentMail = studentRequest.ParentMail,
                ParentStatus = studentRequest.ParentStatus
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }
        public async Task<Student> GetStudentWithUserAsync(string applicationUserId)
        {
            return await dbContext.Students
                .Include(s => s.ApplicationUser)
                .FirstOrDefaultAsync(s => s.ApplicationUserId == applicationUserId);
        }

    }
}
