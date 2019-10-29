using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IndianRestaurant.Data;
using IndianRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndianRestaurant.Areas.Admin
{
    [Area("Admin")]
    public class CouponController : Controller
    {

        //readonly property allows value to be genertated at runtime
        private readonly ApplicationDbContext _db;

        public CouponController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task <IActionResult> Index()
        {
            return View(await _db.Coupon.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                //fetch the file which was uploaded for the image 
                var files = HttpContext.Request.Form.Files;
                if (files.Any())
                {
                    byte[] p1 = null;
                    //Converting image into bytes and store it into p1
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    //add to coupon in db
                    coupon.Picture = p1;
                }

                _db.Coupon.Add(coupon);
                await _db.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            return View(coupon);

        }

        //GET - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _db.Coupon.FindAsync(id));
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(Coupon coupon)
        {

            if (coupon.Id == 0)
            {
                return NotFound();
                }
            Coupon couponFromDb = await _db.Coupon.FindAsync(coupon.Id);

            if (!ModelState.IsValid)
            {

                return View(coupon);
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Any())
            {
                byte[] p1 = null;
                //Converting image into bytes and store it 
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }

                couponFromDb.Picture = p1;
            }

            couponFromDb.Name = coupon.Name;
            couponFromDb.CouponType = coupon.CouponType;
            couponFromDb.Discount = coupon.Discount;
            couponFromDb.IsActivated = coupon.IsActivated;
            couponFromDb.MinimumAmount = coupon.MinimumAmount;



            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET - Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coupon couponFromDb = await _db.Coupon.FindAsync(id);

            return View(couponFromDb);
        }


        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _db.Coupon.FindAsync(id));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            _db.Coupon.Remove(await _db.Coupon.FindAsync(id));
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}