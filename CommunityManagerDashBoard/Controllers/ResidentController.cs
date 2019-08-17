using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityManagerDashBoard.Data;
using CommunityManagerDashBoard.Models;
using CommunityManagerDashBoard.ViewModels;
using CommunityManagerDashBoard.Data.Repositories;

namespace CommunityManagerDashBoard.Controllers
{
    public class ResidentController : Controller
    {
       
        private Factory repositoryFactory;

        public ResidentController(Factory repositoryFactory)

        {
            this.repositoryFactory = repositoryFactory;

        }

        public IActionResult Index()
        {
            List<ResidentListViewModel> residents = ResidentListViewModel.GetResident(repositoryFactory);
            return View(residents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ResidentCreateViewModel model = new ResidentCreateViewModel(repositoryFactory);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ResidentCreateViewModel model)
        {

            model.Persist(repositoryFactory);
            return RedirectToAction(controllerName: nameof(Resident), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            return View( new ResidentEditViewModel(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, ResidentEditViewModel resident)
        {   
            
            resident.Persist(id, repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
           repositoryFactory.GetResidentRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }

       
    }

}