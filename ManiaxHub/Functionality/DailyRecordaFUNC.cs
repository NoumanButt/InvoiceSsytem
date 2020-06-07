using ManiaxHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManiaxHub.Functionality
{
    public class DailyRecordaFUNC
    {
        ManiaXEntities db = new ManiaXEntities();
        public List<DailyRecord> RecordsList(string Data, string SearchType , string CustomerCode)
        {
            var CurrentDate = DateTime.Now.Date;
            //List<long> CustomerIDs = new List<long>();
            //var Customers = (from c in db.Customers.Where(a => a.CustomerID == CustomerID) select new { c.CustomerID }).Distinct();
            //foreach (var users in Customers)
            //{
            //    CustomerIDs.Add(users.CustomerID);
            //}

            if ((Data != "" && Data != null) && (SearchType != "" && SearchType != null))
            {
                if (SearchType == "Date")
                {
                    DateTime Date = Convert.ToDateTime(Data);
                    var DailyRecordList = (from m in db.DailyRecords where /*CustomerIDs.Contains(m.RecordID) &&*/ m.RecordDate == Date select m).ToList();
                    return DailyRecordList;
                    //else
                    //{
                    //    DateTime Date = Convert.ToDateTime(Data);
                    //    var WarehousePurchaseOrderList = (from m in db.tblWarehousePurchaseOrders where WarehouseIDs.Contains(m.WarehouseID) && m.OrderDate == Date && m.OrderDate == CurrentDate select m).Include(a => a.tblSuppliers.tblPersons).Include(a => a.tblWarehouses).Include(a => a.tblItems).Include(a => a.tblItems1).ToList();
                    //    return WarehousePurchaseOrderList;
                    //}
                }
                else if(SearchType == "CustomerID")
                {
                    long CustomerID = Convert.ToInt64(CustomerCode);
                    var DailyRecordList = (from m in db.DailyRecords where /*CustomerIDs.Contains(m.RecordID) &&*/ m.CustomerID == CustomerID select m).ToList();
                    return DailyRecordList;

                    //}
                    //else
                    //{
                    //    var WarehousePurchaseOrderList = (from m in db.tblWarehousePurchaseOrders where WarehouseIDs.Contains(m.WarehouseID) && m.tblWarehouses.Warehouse == Data && m.OrderDate == CurrentDate select m).Include(a => a.tblSuppliers.tblPersons).Include(a => a.tblWarehouses).Include(a => a.tblItems).Include(a => a.tblItems1).ToList();
                    //    return WarehousePurchaseOrderList;
                    //}
                }
                else
                {
                    var DailyRecordList = (from m in db.DailyRecords where /*WarehouseIDs.Contains(m.WarehouseID) &&*/  m.RecordDate == CurrentDate select m).ToList();
                    return DailyRecordList;
                }
            }
            //    else if (SearchType == "SupplierID")
            //    {
            //        if (Check.Date)
            //        {
            //            var WarehousePurchaseOrderList = (from m in db.tblWarehousePurchaseOrders where WarehouseIDs.Contains(m.WarehouseID) && m.tblSuppliers.tblPersons.FirstName + " " + m.tblSuppliers.tblPersons.LastName == Data select m).Include(a => a.tblSuppliers.tblPersons).Include(a => a.tblWarehouses).Include(a => a.tblItems).Include(a => a.tblItems1).ToList();
            //            return WarehousePurchaseOrderList;
            //        }
            //        else
            //        {
            //            var WarehousePurchaseOrderList = (from m in db.tblWarehousePurchaseOrders where WarehouseIDs.Contains(m.WarehouseID) && m.tblSuppliers.tblPersons.FirstName + " " + m.tblSuppliers.tblPersons.LastName == Data && m.OrderDate == CurrentDate select m).Include(a => a.tblSuppliers.tblPersons).Include(a => a.tblWarehouses).Include(a => a.tblItems).Include(a => a.tblItems1).ToList();
            //            return WarehousePurchaseOrderList;
            //        }
            //    }
            //    else
            //    {
            //        if (Check.Date)
            //        {
            //            long OrderNo = Convert.ToInt64(Data);
            //            var WarehousePurchaseOrderList = (from m in db.tblWarehousePurchaseOrders where WarehouseIDs.Contains(m.WarehouseID) && m.OrderNo == OrderNo select m).Include(a => a.tblSuppliers.tblPersons).Include(a => a.tblWarehouses).Include(a => a.tblItems).Include(a => a.tblItems1).ToList();
            //            return WarehousePurchaseOrderList;
            //        }
            //        else
            //        {
            //            long OrderNo = Convert.ToInt64(Data);
            //            var WarehousePurchaseOrderList = (from m in db.tblWarehousePurchaseOrders where WarehouseIDs.Contains(m.WarehouseID) && m.OrderNo == OrderNo && m.OrderDate == CurrentDate select m).Include(a => a.tblSuppliers.tblPersons).Include(a => a.tblWarehouses).Include(a => a.tblItems).Include(a => a.tblItems1).ToList();
            //            return WarehousePurchaseOrderList;
            //        }
            //    }
            //}
            else
            {
                var DailyRecordList = (from m in db.DailyRecords where /*WarehouseIDs.Contains(m.WarehouseID) &&*/ m.RecordDate == CurrentDate select m).ToList();
                return DailyRecordList;
            }
        }
    }
}