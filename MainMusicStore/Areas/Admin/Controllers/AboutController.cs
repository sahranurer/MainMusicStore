using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainMusicStore.DataAccess.IMainRepository;
using Microsoft.AspNetCore.Mvc;

namespace MainMusicStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {


        private readonly IUnitOfWork _uow;
        public AboutController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
