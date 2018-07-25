using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVC.Models;

namespace MovieRentalMVC.Controllers
{
    public class RentalsController : Controller
    {
        private MovieRentalMVCContext db = new MovieRentalMVCContext();

        // GET: Rentals
        public ActionResult Index()
        {
            var rentals = db.Rentals.Include(r => r.Customer).Include(r => r.Movie);
            return View(rentals.ToList());
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "FirstName");
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RentalDate,CustomerID,MovieId")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rentals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "FirstName", rentals.CustomerID);
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title", rentals.MovieId);
            return View(rentals);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "FirstName", rentals.CustomerID);
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title", rentals.MovieId);
            return View(rentals);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RentalDate,CustomerID,MovieId")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "FirstName", rentals.CustomerID);
            ViewBag.MovieId = new SelectList(db.Movies, "ID", "Title", rentals.MovieId);
            return View(rentals);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentals rentals = db.Rentals.Find(id);
            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rentals rentals = db.Rentals.Find(id);
            db.Rentals.Remove(rentals);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //public ActionResult Search()
        //{

        //    return View(new SearchMasterViewModel());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Search([Bind(Include = "SearchText")] SearchMasterViewModel model)
        //{
        //    model.MovieResult = (from c in db.Movies where c.Title.Contains(model.SearchText) select c).ToList();
        //    return View();
        //}

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
