using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMCGWebApp.Gateway;
using FMCGWebApp.Models;

namespace FMCGWebApp.Manager
{
    public class PasswordAndDesignationManager
    {
        private PasswordAndDesignationGateway _passwordAndDesignation = new PasswordAndDesignationGateway();
        private ShopInfoGateway _shopInfoGateway = new ShopInfoGateway();
        public List<Employee> ListOfEmployee()
        {
            return _shopInfoGateway.GetAllEmployees();
        }

        public List<UserType> GetUserType()
        {
            return _passwordAndDesignation.GetUserType();
        }

        public bool IsPasswordSet(EmployeePassword employee)
        {
            return _passwordAndDesignation.IsPasswordSet(employee);
        }

        public int SetEmployeePassword(EmployeePassword employee)
        {
            return _passwordAndDesignation.SetEmployeePassword(employee);
        }

        public List<Employee> GetEmployeeById(int id)
        {
            return _passwordAndDesignation.GetEmployeeById(id);
        }

        public bool IsUserRoleSet(EmployeeUserType employee)
        {
            return _passwordAndDesignation.IsUserRoleSet(employee);
        }

        public int SetEmployeeUserType(EmployeeUserType employee)
        {
            return _passwordAndDesignation.SetEmployeeUserType(employee);
        }
    }
}