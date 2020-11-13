using Dapper;
using MainMusicStore.DataAccess.IMainRepository;
using MainMusicStore.Models.DbModels;
using MainMusicStore.Utility;
using Microsoft.AspNetCore.Mvc;

namespace MainMusicStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {


        #region Variables
        private readonly IUnitOfWork _uow; 
        #endregion


        #region CTOR
        public CoverTypeController(IUnitOfWork uow)
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
            var allObj = _uow.CoverType.GetAll();

            // var allCoverTypes = _uow.sp_call.List<CoverType>(ProjectConstant.Proc_CoverType_GetAll,null);

            return Json(new { data = allObj });
        }
        #endregion

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
             var deleteData = _uow.CoverType.Get(Id);
             if (deleteData == null)
             {
              return Json(new { success = false, message = "Data Not Found" });
            }
             _uow.CoverType.Remove(deleteData);
             _uow.Save();
            return Json(new { success = true, message = "Delete Operation Successfully" });

            // var parameter = new DynamicParameters();
            //parameter.Add("@Id", Id);


            //var deleteData = _uow.sp_call.OneRecord<CoverType>(ProjectConstant.Proc_CoverType_Get, parameter);
            //if (deleteData == null) 
            //return Json(new { success = false, message = "Data Not Found" });


            //_uow.sp_call.Execute(ProjectConstant.Proc_CoverType_Delete, parameter);
            //_uow.Save();
            //return Json(new { success = true, message = "Delete Operation Successfully" });
        }



        [HttpGet]
        public IActionResult Upsert(int? Id)
        {
            CoverType cov = new CoverType();
            if (Id == null)
            {
                return View(cov);
            }

            //var paramater = new DynamicParameters();
            //paramater.Add("@Id",Id);
            //cov = _uow.sp_call.OneRecord<CoverType>(ProjectConstant.Proc_CoverType_Get, paramater);


            cov = _uow.CoverType.Get((int)Id);
            if (cov != null)
            {
                return View(cov);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType CoverType)
        {
            if (ModelState.IsValid)
            {
                // var paramater = new DynamicParameters();
                // paramater.Add("@Name", CoverType.Name);
                if (CoverType.Id == 0)
                {
                    //Create
                    _uow.CoverType.Add(CoverType);
                    // _uow.sp_call.Execute(ProjectConstant.Proc_CoverType_Create,paramater);
                }
                else
                {
                    //Update
                     _uow.CoverType.Update(CoverType);
                    // paramater.Add("@Id", CoverType.Id);
                    // _uow.sp_call.Execute(ProjectConstant.Proc_CoverType_Update, paramater);

                }
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(CoverType);
        }

        
    }
}
