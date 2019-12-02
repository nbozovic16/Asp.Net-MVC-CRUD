using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //View result
        public ActionResult ViewAll()
        {
            return View(GetAllProduct()); //passing function int view
        }

        //collection of products
        IEnumerable<Product>GetAllProduct()
        {
            using (DBModel db = new DBModel()) //db ref.
            {
                return db.Products.ToList<Product>(); //covnert list to product list
            }
        }

        //Inset and edit operation
        public ActionResult AddOrEdit(int id = 0)
        {
            Product prd = new Product();
            if(id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    prd = db.Products.Where(x => x.id == id).FirstOrDefault<Product>();
                }
            }
            return View(prd);
        }

        //continued
        [HttpPost]
        public ActionResult AddOrEdit(Product prd)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (prd.id == 0)
                    {
                        db.Products.Add(prd); //insert operation
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(prd).State = EntityState.Modified; //edit operation
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllProduct()), message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        //Delete function
        public ActionResult Delete(int id)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    Product prd = db.Products.Where(x => x.id == id).FirstOrDefault<Product>();
                    db.Products.Remove(prd);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllProduct()), message = "Delited Successfully" }, JsonRequestBehavior.AllowGet);
            }

            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}