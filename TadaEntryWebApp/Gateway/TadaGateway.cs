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
            connectionString = WebConfigurationManager.ConnectionStrings["TadaEntryDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
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
                tadaHistory.TotalCost = tadaHistory.TravelCost + tadaHistory.LunchCost + tadaHistory.InstrumentCost;
                tadaList.Add(tadaHistory);

            }
            connection.Close();
            return tadaList;
        }


        public int UpdateIsPaid(int tadaHistoryId)
        {
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