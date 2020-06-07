using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManiaxHub.Functionality;
using ManiaxHub.Models;

namespace ManiaxHub.Controllers
{
    public class DailyRecordsController : Controller
    {
        private ManiaXEntities db = new ManiaXEntities();
        private DailyRecordaFUNC DailyRecordaFUNC = new DailyRecordaFUNC();
        // GET: DailyRecords
        public ActionResult Index(int? page, string All, string Data, string SearchType)
            {
            string CustomerCode = Convert.ToString(Session["CustomerCode"]);
            ViewBag.SearchType = SearchType;
            ViewBag.Data = Data;
            var dailyRecords = DailyRecordaFUNC.RecordsList(Data, SearchType, CustomerCode).ToList(); //db.DailyRecords.Include(d => d.Customer);
            return View(dailyRecords.ToList());
        }

        // GET: DailyRecords/Details/5
        //public ActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DailyRecord dailyRecord = db.DailyRecords.Find(id);
        //    if (dailyRecord == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dailyRecord);
        //}

        // GET: DailyRecords/Create
        public ActionResult Create()
        {
            var CurrentDate = DateTime.Now.Date;
            ViewBag.RecordDate = (CurrentDate).ToString("dd-MMM-yyyy");
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName");
            return View();
        }

        // POST: DailyRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID,CustomerID,RecordDate,Coins,Food,StartingTime,EndingTime,TotalAmount,Balance,Credit,Debit")] DailyRecord dailyRecord)
        {
            var id = dailyRecord.CustomerID;
            DailyRecord dr = db.DailyRecords.Find(id);
            //Customer c = new Customer();
            Customer customer = db.Customer.Find(id);
            if (ModelState.IsValid)
            {
                db.DailyRecords.Add(dailyRecord);
                try
                {
                    customer.Credit = Convert.ToInt32(dailyRecord.Credit);
                }
                catch (Exception e)
                {

                    throw e;
                }
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", dailyRecord.CustomerID);
            return View(dailyRecord);
        }

        // GET: DailyRecords/Edit/5
        public ActionResult Edit(long? id)
        {
            Session["CustomerCode"] = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyRecord dailyRecord = db.DailyRecords.Find(id);
            if (dailyRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", dailyRecord.CustomerID);
            return View(dailyRecord);
        }

        // POST: DailyRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordID,CustomerID,RecordDate,Coins,Food,StartingTime,EndingTime,TotalAmount,Balance,Credit,Debit")] DailyRecord dailyRecord)
        {
            
            var id = Convert.ToString(Session["CustomerCode"]);
            var id1 = dailyRecord.CustomerID;
            Customer customer = db.Customer.Find(id1);
            if (ModelState.IsValid)
            {
                db.Entry(dailyRecord).State = EntityState.Modified;
                customer.Credit = Convert.ToInt32(dailyRecord.Credit);
                db.SaveChanges();
                return RedirectToAction("Index");
                // return RedirectToAction("Edit/" + id);
            }
            ViewBag.CustomerID = new SelectList(db.Customer , "CustomerID", "CustomerName", dailyRecord.CustomerID);
            return RedirectToAction("Index");
           // return View(dailyRecord);



            //var id = Convert.ToString(Session["CustomerCode"]);
            //if (ModelState.IsValid)
            //{
            //    db.Entry(dailyRecord).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Edit/" + id);
            //}

            //ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", dailyRecord.CustomerID);
            //db.Entry(dailyRecord).State = EntityState.Modified;
            //return RedirectToAction("Index");
            //db.SaveChanges();
            
        }


        // GET: DailyRecords/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyRecord dailyRecord = db.DailyRecords.Find(id);
            if (dailyRecord == null)
            {
                return HttpNotFound();
            }
            return View(dailyRecord);
        }

        // POST: DailyRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DailyRecord dailyRecord = db.DailyRecords.Find(id);
            db.DailyRecords.Remove(dailyRecord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // testing Code
        //Search EmployeeCode autoComplete
        public JsonResult CustomersList(string term)
        {
            var CustomerCodeList = (from a in db.Customer
                                    select new { value = a.CustomerID, label = a.CustomerName }).Distinct().ToList();

            return Json(CustomerCodeList, JsonRequestBehavior.AllowGet);
        }
        //EmployeeCodeID in session
        public JsonResult CustomerCodeID(string label)
        {
            Session["CustomerCode"] = label;
            return Json(new { data = true }, JsonRequestBehavior.AllowGet);
        }
        //....................

        //public ActionResult CustomersList()
        //{
        //    var CustomersList = (from a in db.Customers
        //                         select new { value = a.CustomerID, label = a.CustomerName }).Distinct().ToList();

        //    return Json(CustomersList, JsonRequestBehavior.AllowGet);
        //}
        ////EmployeeCodeID in session
        //public JsonResult CustomerCodeID(string label)
        //{
        //    Session["CustomerCode"] = label;
        //    return Json(new { data = true }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult PostCreduit()
        {
            var CurrentDate = DateTime.Now.Date;
            //var creditList = (from m in db.DailyRecords where EntityFunctions.TruncateTime(m.RecordDate) == CurrentDate select (m.Credit)).ToList();
            var CustomerIDList = db.DailyRecords.Where(a => EntityFunctions.TruncateTime(a.RecordDate) == CurrentDate).Select(i => new { i.CustomerID, i.Credit }).ToList();
            Customer c = new Customer();
            foreach (var item in CustomerIDList)
            {
                Customer customer = db.Customer.Find(item.CustomerID);
                customer.Credit = Convert.ToInt32(item.Credit);
                db.SaveChanges();
            }
            return View(c);
        }

        public JsonResult GetCredit(int id)
        {
            var CustomerCredit = db.Customer.Where(a => a.CustomerID == id).Select(i => new { i.Credit });
            return Json(CustomerCredit, JsonRequestBehavior.AllowGet);
           }

    }
}
