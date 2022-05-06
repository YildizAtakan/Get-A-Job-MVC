using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using getajob.Data;
using getajob.Models;

namespace getajob.Controllers
{
    [Authorize(Roles = "Administrator,Standart Account")]
    public class ListingsController : Controller
    {
        private readonly ListingContext db = new ListingContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Listings);
        }

        public ActionResult Index2()
        {
            return View(db.Listings.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var listing = db.Listings.Find(id);
            if (listing == null) return HttpNotFound();

            return View(listing);
        }

        [AllowAnonymous]
        public ActionResult Details2(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var listing = db.Listings.Find(id);
            if (listing == null) return HttpNotFound();

            return View(listing);
        }


        // GET: Listings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
                "ID,ListingCreator,ListingName,ListingCompany,listingPicture,listingText,listingContact")]
            Listing listing)
        {
            listing.ListingCreator = User.Identity.Name;
            Console.WriteLine(User.Identity.Name);
            Console.WriteLine(User.Identity.Name);
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listing);
        }

        // GET: Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var listing = db.Listings.Find(id);
            if (listing == null) return HttpNotFound();

            //ViewBag.creator = listing.ListingCreator;
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
                "ID,ListingCreator,ListingName,ListingCompany,listingPicture,listingText,listingContact")]
            Listing listing)
        {
            //listing.ListingCreator = a;
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var listing = db.Listings.Find(id);
            if (listing == null) return HttpNotFound();

            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }
    }
}