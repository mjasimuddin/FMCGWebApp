using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMCGWebApp.Gateway;
using FMCGWebApp.Models;

namespace FMCGWebApp.Manager
{
    public class WhouseinfoManager
    {
        private WhouseinfoGateway _whouseinfo = new WhouseinfoGateway();

        public string SaveWhouse(W_h_info wHInfo)
        {
            if (_whouseinfo.IsWhouseExists(wHInfo))
            {
                return "Category Name Already Exists.";
            }
            if (_whouseinfo.SaveWhouse(wHInfo) > 0)
            {
                return "Category Name Saved Successfully";
            }

            return "Category Name Save Faild";
        }
    }
}