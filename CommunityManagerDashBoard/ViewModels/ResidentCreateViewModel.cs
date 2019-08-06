using CommunityManagerDashBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityManagerDashBoard.ViewModels
{
    public class ResidentCreateViewModel
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LotNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public ResidentCreateViewModel ()
        {


        }

        public void Persist(Factory repositoryFactory)
        {
            Models.Resident resident = new Models.Resident
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                LotNumber = this.LotNumber,
                PhoneNumber = this.PhoneNumber,
                Email = this.Email
            };
            repositoryFactory.GetResidentRepository().Save(resident);
         }





    }
}
