using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMCGWebApp.Gateway;
using FMCGWebApp.Models;

namespace FMCGWebApp.Manager
{
    public class EmployeeManager
    {
        private EmployeeGateway employeeGateway = new EmployeeGateway();

        public int AddEmployee(Employee employee)
        {
            return employeeGateway.AddEmployee(employee);
        }
        public List<Gender> GetGenderList()
        {
            return employeeGateway.GetGenderList();
        }
        public bool IsEmailExists(string email)
        {
            return employeeGateway.IsEmailExist(email);
        }
    }
}