using CommunityManagerDashBoard.Data.Repositories;
using CommunityManagerDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace CommunityManagerDashBoard.ViewModels
{
    public class ResidentEditViewModel
    {
       // private readonly Factory repositoryFactory;
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Lot Number")]
        public int LotNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }


        public ResidentEditViewModel()
        {

        }
        public ResidentEditViewModel(int id)
        {

        }
        public ResidentEditViewModel(Factory repositoryFactory)
        {

        }

        public ResidentEditViewModel(int id, Factory repositoryFactory)
        {
            Resident resident = repositoryFactory.GetResidentRepository().GetById(id);
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
                
                FirstName = this.FirstName,
                LastName = this.LastName,
                LotNumber = this.LotNumber,
                PhoneNumber = this.PhoneNumber,
                Email = this.Email
            };
            repositoryFactory.GetResidentRepository().Update(resident);
        }
    }
}
