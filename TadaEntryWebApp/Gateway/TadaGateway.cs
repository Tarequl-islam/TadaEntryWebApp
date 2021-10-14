using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TadaEntryWebApp.Models;

namespace TadaEntryWebApp.Gateway
{
    public class TadaGateway
    { 
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public TadaGateway()
        {
            // connection string to access Database Server. Database link Saved in the Web.config
            connectionString = WebConfigurationManager.ConnectionStrings["TadaEntryDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        // Getting all the employees from database
        public List<Employee> GetAllEmployee()
        {
            string query = "SELECT * FROM Employee";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(reader["Id"]);
                employee.Name = reader["Name"].ToString();
                employeeList.Add(employee);

            }
            connection.Close();
            return employeeList;
        }

        // Saving TADA History to the Database
        public int Save(Tada tada)
        {
            string query = "INSERT INTO TadaHistory(EmployeeId, TravelCost, LunchCost, InstrumentCost, IsPaid, Date) VALUES(@EmployeeId, @TravelCost, @LunchCost, @InstrumentCost, @IsPaid, @Date)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeId", tada.EmployeeId);
            command.Parameters.AddWithValue("@TravelCost", tada.TravelCost);
            command.Parameters.AddWithValue("@LunchCost", tada.LunchCost);
            command.Parameters.AddWithValue("@InstrumentCost", tada.InstrumentCost);
            command.Parameters.AddWithValue("@IsPaid", tada.IsPaid);
            command.Parameters.AddWithValue("@Date", tada.Date);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        // Getting TADA Histories from Database
        public List<TadaHistory> GetTadaHistory()
        {
            string query = "SELECT * FROM TadaHistoryView";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<TadaHistory> tadaList = new List<TadaHistory>();
            while (reader.Read())
            {
                TadaHistory tadaHistory = new TadaHistory();
                tadaHistory.Id = Convert.ToInt32(reader["Id"]);
                tadaHistory.Date = reader["Date"].ToString();
                tadaHistory.Name = reader["Name"].ToString();
                tadaHistory.TravelCost = Convert.ToInt32(reader["TravelCost"]);
                tadaHistory.LunchCost = Convert.ToInt32(reader["LunchCost"]);
                tadaHistory.InstrumentCost = Convert.ToInt32(reader["InstrumentCost"]);
                tadaHistory.IsPaid = Convert.ToBoolean(reader["IsPaid"]);
                // Adding Total Cost from Travel cost, Lunch Cost and Instrument Cost
                tadaHistory.TotalCost = tadaHistory.TravelCost + tadaHistory.LunchCost + tadaHistory.InstrumentCost;
                tadaList.Add(tadaHistory);

            }
            connection.Close();
            return tadaList;
        }

        // Updating Paid Status to Database
        public int UpdateIsPaid(int tadaHistoryId)
        {
            // Toggling The Paid status base on toggle switch in the UI.  IsPaid^1 means if IsPaid is 0 then making it 1 and vise-versa
            string query = "UPDATE TadaHistory SET IsPaid = IsPaid^1 WHERE Id = @TadaHistoryId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TadaHistoryId", tadaHistoryId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

    }
}