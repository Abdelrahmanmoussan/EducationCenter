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
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly AppDbContext dbContext;

        public SubjectRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            dbContext = appDbContext;
        }
    }
}
