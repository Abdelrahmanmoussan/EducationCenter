using EducationCenter.DataAccess.Data;
using EducationCenter.DataAccess.Repository.IRepository;
using EducationCenter.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.DataAccess.Repository
{
    internal class SubjectAcademicYearRepository : Repository<SubjectAcademicYear> , ISubjectAcademicYearRepository
    {
        private readonly AppDbContext dbContext;

        public SubjectAcademicYearRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }
    }
}
