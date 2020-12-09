﻿using MainMusicStore.DataAccess.IMainRepository;
using MainMusicStore.Models.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MainMusicStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {


        #region Variables
        private readonly IUnitOfWork _uow; 
        #endregion


        #region CTOR
        public CompanyController(IUnitOfWork uow)
        {
            _uow = uow;
        }  
        #endregion


        #region Actions
        public IActionResult Index()
        {
            return View();
        } 
        #endregion

        #region API CALLS
        public IActionResult GetAll()
        {
            var allObj = _uow.Company.GetAll();
            return Json(new { data = allObj });
        }
        #endregion

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var deleteData = _uow.Company.Get(Id);
            if (deleteData == null)
            {
                return Json(new { success = false, message = "Data Not Found" });
            }
            _uow.Company.Remove(deleteData);
            _uow.Save();
            return Json(new { success = true, message = "Delete Operation Successfully" });
        }



        [HttpGet]
        public IActionResult Upsert(int? Id)
        {
            Company cat = new Company();
            if (Id == null)
            {
                return View(cat);
            }

            cat = _uow.Company.Get((int)Id);

            if (cat != null)
            {
                return View(cat);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company Company)
        {
            if (ModelState.IsValid)
            {
                if (Company.Id == 0)
                {
                    //Create
                    _uow.Company.Add(Company);
                }
                else
                {
                    //Update
                    _uow.Company.Update(Company);
                }
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(Company);
        }

        
    }
}
