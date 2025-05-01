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
    public class PrivateLessonTeacherRepository : Repository<PrivateLessonTeacher>, IPrivateLessonTeacherRepository
    {
        private readonly AppDbContext dbContext;

        public PrivateLessonTeacherRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        } 
    }
}
