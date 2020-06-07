using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManiaxHub.Models;

namespace ManiaxHub.Controllers
{
    public class tblLoginsController : Controller
    {
        private ManiaXEntities db = new ManiaXEntities();

        // GET: tblLogins
        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            Session["Pssword"] =   null;
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Create", "tblLogins");
        }

        // GET: tblLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = db.tblLogins.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // GET: tblLogins/Create
        public ActionResult Create()
        {
            Session["UserName"] = null;
            Session["Pssword"] = null;
            Session.Abandon();
            return View();
        }

        // POST: tblLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,Pasword")] tblLogin tblLogin)

        {
            var check = db.tblLogins.Where(x => x.UserName == tblLogin.UserName.Trim() && x.Pasword == tblLogin.Pasword.Trim()).FirstOrDefault();
            if (check != null)
            {
                Session["UserName"] = tblLogin.UserName;
                Session["Password"] = tblLogin.Pasword;
                if (Session["UserName"] != null){ 
                return RedirectToAction("Index", "DailyRecords");
                }
                else
                {
                    ViewBag.alert = "Invalid UserName or Pasword";
                }    
            }
            else
            {
                ViewBag.alert = "Invalid UserName or Pasword";
            }


            //if (ModelState.IsValid)
            //{
            //    db.tblLogins.Add(tblLogin);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(tblLogin);
        }

        // GET: tblLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = db.tblLogins.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // POST: tblLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Pasword")] tblLogin tblLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLogin);
        }

        // GET: tblLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = db.tblLogins.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // POST: tblLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLogin tblLogin = db.tblLogins.Find(id);
            db.tblLogins.Remove(tblLogin);
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
    }
}



//namespace ManiaxHub.Controllers
//{
//    public class tblLoginsController : Controller
//    {
//        private ManiaXEntities db = new ManiaXEntities();

//        // GET: tblLogins
//        public ActionResult Index()
//        {
//            return View(db.tblLogins.ToList());
//        }

//        // GET: tblLogins/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            tblLogin tblLogin = db.tblLogins.Find(id);
//            if (tblLogin == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tblLogin);
//        }

//        // GET: tblLogins/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: tblLogins/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "UserID,UserName,Pasword")] tblLogin tblLogin)
//        {
//            if (ModelState.IsValid)
//            {
//                db.tblLogins.Add(tblLogin);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(tblLogin);
//        }

//        // GET: tblLogins/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            tblLogin tblLogin = db.tblLogins.Find(id);
//            if (tblLogin == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tblLogin);
//        }

//        // POST: tblLogins/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "UserID,UserName,Pasword")] tblLogin tblLogin)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(tblLogin).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(tblLogin);
//        }

//        // GET: tblLogins/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            tblLogin tblLogin = db.tblLogins.Find(id);
//            if (tblLogin == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tblLogin);
//        }

//        // POST: tblLogins/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            tblLogin tblLogin = db.tblLogins.Find(id);
//            db.tblLogins.Remove(tblLogin);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
