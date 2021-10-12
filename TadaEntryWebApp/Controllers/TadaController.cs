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
        // GET: /Tada/
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.IsPaid = IdPaidForDropdown();
            ViewBag.Employees = GetEmployeesForDropdown();
            return View();
        }
        // Save: /Tada/ 
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



        // All Business logic goes here
        public List<SelectListItem> IdPaidForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "--Select--", Value = ""},
                new SelectListItem(){ Text = "Paid", Value = "1"},
                new SelectListItem(){ Text = "Not Paid", Value = "0"}
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