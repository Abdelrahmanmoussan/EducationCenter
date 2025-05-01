using EducationCenter.Models.DTOs.Request;
using EducationCenter.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.DataAccess.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> CreateStudentAsync(StudentRequest studentRequest, string userId);
        Task<Student> GetStudentWithUserAsync(string applicationUserId);
    }
}
