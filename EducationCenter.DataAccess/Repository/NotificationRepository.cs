
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
    internal class NotificationRepository : Repository<Notification> , INotificationRepository
    {
        private readonly AppDbContext dbContext;

        public NotificationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }
    }
}
