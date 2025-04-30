using EducationCenter.DataAccess.Data;
using EducationCenter.DataAccess.Repository.IRepository;
using EducationCenter.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.DataAccess.Repository
{
    internal class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AppDbContext dbContext;

        public StudentRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            dbContext = appDbContext;
        }
    }
}
