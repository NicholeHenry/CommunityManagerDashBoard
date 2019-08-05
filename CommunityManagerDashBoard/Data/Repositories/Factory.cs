using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityManagerDashBoard.Models;

namespace CommunityManagerDashBoard.Data.Repositories
{
    public class Factory
    {

        private ApplicationDbContext context;

        public Factory(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public IRepository<Resident> GetResidentRepository()
        {
            return new BaseRepository<Resident>(context);
        }
    }
}
