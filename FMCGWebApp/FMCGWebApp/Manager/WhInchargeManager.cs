using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMCGWebApp.Gateway;
using FMCGWebApp.Models;

namespace FMCGWebApp.Manager
{
    public class WhInchargeManager
    {
         private WhInchargeGateway _incharge = new WhInchargeGateway();
         public List<Stockout> SellOrderList()
        {
            return _incharge.SellOrderList();
        } 
    }
}