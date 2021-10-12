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


        //public int SaveResult(Result tada)
        //{
        //    string query = "INSERT INTO Result(StudentId, CourceId, GradeId) VALUES(@StudentId, @CourceId, @GradeId)";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@StudentId", tada.StudentId);
        //    command.Parameters.AddWithValue("@CourceId", tada.CourceId);
        //    command.Parameters.AddWithValue("@GradeId", tada.GradeId);
        //    connection.Open();
        //    int rowAffect = command.ExecuteNonQuery();
        //    connection.Close();
        //    return rowAffect;
        //}

    }
}