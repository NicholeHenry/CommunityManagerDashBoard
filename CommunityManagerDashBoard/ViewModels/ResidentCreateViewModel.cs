using CommunityManagerDashBoard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityManagerDashBoard.ViewModels
{
    public class ResidentCreateViewModel
    {
       [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Lot Number")]
        public int LotNumber { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        public ResidentCreateViewModel()
        {

        }
   
        public ResidentCreateViewModel (Factory repositoryFactory)
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
