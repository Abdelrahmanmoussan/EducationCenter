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
    internal class AssessmentResultRepository : Repository<AssessmentResult> , IAssessmentResultRepository
    {
        private readonly AppDbContext dbContext;

        public AssessmentResultRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }
    }
}
