using CommunityManagerDashBoard.Data.Repositories;
using CommunityManagerDashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityManagerDashBoard.ViewModels
{
    public class ResidentListViewModel
    {
        

        public static List<ResidentListViewModel>GetResident(Factory repositoryFactory)
        {
            return repositoryFactory.GetResidentRepository()
                .GetModels()
                .Select(r => new ResidentListViewModel(r))
                .ToList();

        }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LotNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        
      public ResidentListViewModel(Resident resident)
        {
                 this.Id = resident.Id;
                 this.FirstName = resident.FirstName;
                 this.LastName = resident.LastName;
                 this.LotNumber = resident.LotNumber;
                 this.PhoneNumber = resident.PhoneNumber;
                 this.Email = resident.Email;
        }
    }
}
