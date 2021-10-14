using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TadaEntryWebApp.Gateway;
using TadaEntryWebApp.Models;

namespace TadaEntryWebApp.Manager
{
    // All the business logic goes here
    public class TadaManager
    {
        private TadaGateway tadaGateway;

        public TadaManager()
        {
            tadaGateway = new TadaGateway();
        }

        // Taking values and Text for Paid and Unpaid. for Simplicity, we are not creating another Table in the database
        public List<SelectListItem> IdPaidForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()  //using selectListItem object to show in the dropdown
            {
                new SelectListItem(){ Text = "--Select--", Value = ""},
                new SelectListItem(){ Text = "Paid", Value = "true"},
                new SelectListItem(){ Text = "Unpaid", Value = "false"}
            };
            return selectListItems;
        }

        // Taking Employees from database and binding them for Dropdown List
        public List<SelectListItem> GetEmployeesForDropdown()
        {
            List<Employee> employees = tadaGateway.GetAllEmployee();
            List<SelectListItem> selectListItems = new List<SelectListItem>()   //using selectListItem object to show in the dropdown
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

        // Saving TADA to Database and returning if it is saved or not
        public string Save(Tada tada)
        {
            int rowAffect = tadaGateway.Save(tada);
            if (rowAffect > 0)
            {
                return "Save Successful!";
            }
            else
            {
                return "Save Failed!";
            }
        }

        // Taking TADA history from database and sorting them to show in the Datatable
        public List<TadaHistory> GetTadaHistory()
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
            return tadaHistory;
        }

        // Updating Paid Status in the database
        public int UpdateIsPaid(int tadaHistoryId)
        {
            int rowEffect = tadaGateway.UpdateIsPaid(tadaHistoryId);
            return rowEffect;
        }

    }
}