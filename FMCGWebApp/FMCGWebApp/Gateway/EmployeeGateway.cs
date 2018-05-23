using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using FMCGWebApp.Models;

namespace FMCGWebApp.Gateway
{
    public class EmployeeGateway
    {
        private SqlConnection _connection = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["FMCGDB"].ConnectionString);
        public int AddEmployee(Employee employee)
        {
            string query = "INSERT INTO tb_Employee (EmployeeName,FatherName,MotherName,GenderId,Email,NationalIdNumber,PhoneNumber,Address) Values('" + employee.EmployeeName + "','" + employee.FatherName + "','" + employee.MotherName + "','" + employee.GenderId + "','" + employee.Email + "','" + employee.NationalIdNumber + "','" + employee.PhoneNumber + "','" + employee.Address + "')";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                return rowAffected;
            }
            catch (Exception exception)
            {

                throw new Exception("Unable to connect Server", exception);
            }
            finally
            {
                _connection.Close();
            }
        }
        public List<Gender> GetGenderList()
        {
            string query = "SELECT * FROM tb_Gender";
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                List<Gender> genderlist = new List<Gender>();
                while (dr.Read())
                {
                    Gender gender = new Gender();
                    gender.Id = (int)dr["Id"];
                    gender.GenderName = dr["GenderName"].ToString();
                    genderlist.Add(gender);
                }
                dr.Close();
                return genderlist;
            }
            catch (Exception exception)
            {

                throw new Exception("Unable to connect Server", exception);
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool IsEmailExist(string email)
        {
            try
            {
                bool isExists = false;

                string query = "SELECT Email FROM tb_Employee WHERE Email= @Email ";
                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.Clear();

                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isExists = true;
                }

                reader.Close();
                return isExists;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to connect Server", exception);
            }
            finally
            {
                _connection.Close();
            }

        }
    }
}