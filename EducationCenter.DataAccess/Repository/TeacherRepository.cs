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
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly AppDbContext dbContext;

        public TeacherRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            dbContext = appDbContext;
        }
    }
}
