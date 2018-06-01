using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMCGWebApp.Gateway;
using FMCGWebApp.Models;
using FMCGWebApp.ViewModels;

namespace FMCGWebApp.Manager
{
    public class SellOrderManager
    {
        private SellOrderGateway _sellOrder = new SellOrderGateway();

        public string SendSellOrder(SellOrder sellOrder)
        {
            if (_sellOrder.IsItemExists(sellOrder))
            {
                if (_sellOrder.IsSellOrderExists(sellOrder))
                {
                    sellOrder.Id = _sellOrder.GetOrderId(sellOrder);
                    if (_sellOrder.UpdateSendSellOrder(sellOrder) > 0)
                    {
                        return "Sell Order Updated!";
                    }

                }
                if (_sellOrder.SendSellOrder(sellOrder) > 0)
                {
                    return "Sell Order Send!";
                }
            }
            else
            {
                return "Sorry! This item are not available";
            }

            return "Order Sending Faild";
        }

        public List<Shop> GetAllShop(int id)
        {
            return _sellOrder.GetAllShop(id);
        }
        public List<Category> GetAllCategory()
        {
            return _sellOrder.GetAllCategory();
        }
        public List<Item> GetAllItem(int id)
        {
            return _sellOrder.GetAllItem(id);
        }
    }
}