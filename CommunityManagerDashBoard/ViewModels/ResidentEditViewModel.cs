using CommunityManagerDashBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityManagerDashBoard.ViewModels
{
    public class ResidentEditViewModel
    {
        private readonly Factory repositoryFactory;
        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LotNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }


        public ResidentEditViewModel(Factory repositoryFactory)
        {

        }

        public ResidentEditViewModel(int id)
        {
            Models.Resident resident = repositoryFactory
                .GetResidentRepository() 
                .GetById(id);
            this.FirstName = resident.FirstName;
            this.LastName = resident.LastName;
            this.LotNumber = resident.LotNumber;
            this.PhoneNumber = resident.PhoneNumber;
            this.Email = resident.Email;
        }
        public void Persist(int id, Factory repositoryFactory)
        {
            Models.Resident resident = new Models.Resident
            {
                Id = id,
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
