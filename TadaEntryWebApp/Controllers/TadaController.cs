using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TadaEntryWebApp.Gateway;
using TadaEntryWebApp.Models;

namespace TadaEntryWebApp.Controllers
{
    public class TadaController : Controller
    {
        private TadaGateway tadaGateway;

        public TadaController()
        {
            tadaGateway = new TadaGateway();
        }
        //
        // GET: /Tada/ Save
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.IsPaid = IdPaidForDropdown();
            ViewBag.Employees = GetEmployeesForDropdown();
            return View();
        }
        //   /Tada/ Save
        [HttpPost]
        public ActionResult Save(Tada tada)
        {
            ViewBag.IsPaid = IdPaidForDropdown();
            ViewBag.Employees = GetEmployeesForDropdown();

            if (ModelState.IsValid)
            {
                int rowAffect = tadaGateway.Save(tada);

                if (rowAffect > 0)
                {
                    ViewBag.Messege = "Save Successful!";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Messege = "Save Failed!";
                }
            }
            else
            {
                ViewBag.Messege = "Model State Invalid";
            }
            return View();
        }

        // GET: /Tada/ Show
        [HttpGet]
        public ActionResult Show()
        {
            List<TadaHistory> tadaHistory = tadaGateway.GetTadaHistory();
            // I have sorted datatables in the Paid order. and sorted them based on date among them. 
            tadaHistory.Sort(
                delegate(TadaHistory p1, TadaHistory p2)
                {
                    int comparePaid = p1.IsPaid.CompareTo(p2.IsPaid);
                    if (comparePaid == 0)
                    {
                        return Convert.ToDateTime(p2.Date).CompareTo(Convert.ToDateTime(p1.Date));
                    }
                    return comparePaid;
                }
            );
            return View(tadaHistory);
        }

        public JsonResult UpdateIsPaid(int tadaHistoryId)
        {
            int rowEffect = tadaGateway.UpdateIsPaid(tadaHistoryId);
            return Json(rowEffect);
        }


        // All Business logic goes here
        public List<SelectListItem> IdPaidForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "--Select--", Value = ""},
                new SelectListItem(){ Text = "Paid", Value = "true"},
                new SelectListItem(){ Text = "Unpaid", Value = "false"}
            };
            return selectListItems;
        }
        public List<SelectListItem> GetEmployeesForDropdown()
        {
            List<Employee> employees = tadaGateway.GetAllEmployee();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "--Select--", Value = ""},
            };
            foreach (Employee employee in employees)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = employee.Name;
                selectListItem.Value = employee.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        
	}
}