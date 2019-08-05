using CommunityManagerDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityManagerDashBoard.Models
{
    public class Resident : IModel
    {
        public int Id { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public int LotNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        
    }
}
