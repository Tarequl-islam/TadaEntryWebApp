using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TadaEntryWebApp.Gateway;
using TadaEntryWebApp.Manager;
using TadaEntryWebApp.Models;

namespace TadaEntryWebApp.Controllers
{
    public class TadaController : Controller
    {
        // Going to Use a Manager Layer to write all the Business Logic
        private TadaManager tadaManager; 

        public TadaController()
        {
            tadaManager = new TadaManager();
        }

        // GET: /Tada/ Save   Method for Save TADA View
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.IsPaid = tadaManager.IdPaidForDropdown();
            ViewBag.Employees = tadaManager.GetEmployeesForDropdown();
            return View();
        }
        //   /Tada/ Save
        [HttpPost]
        public ActionResult Save(Tada tada)
        {
            ViewBag.IsPaid = tadaManager.IdPaidForDropdown();
            ViewBag.Employees = tadaManager.GetEmployeesForDropdown();

            if (ModelState.IsValid)
            {
                string message = tadaManager.Save(tada);
                if (message == "Save Successful!")
                {
                    ModelState.Clear();
                }
                ViewBag.Messege = message;
            }
            else
            {
                ViewBag.Messege = "Model State Invalid";
            }
            return View();
        }

        // GET: /Tada/ Show  Method for Show TADA History View
        [HttpGet]
        public ActionResult Show()
        {
            List<TadaHistory> tadaHistory = tadaManager.GetTadaHistory();

            return View(tadaHistory);  //sending Object to the Model
        }

        // Method For Ajax call to Update database Paid or Not. 
        public JsonResult UpdateIsPaid(int tadaHistoryId)
        {
            int rowEffect = tadaManager.UpdateIsPaid(tadaHistoryId);
            return Json(rowEffect);
        }


        
	}
}