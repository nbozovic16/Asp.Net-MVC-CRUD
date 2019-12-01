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

        //Insert-edit operation
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

        [HttpPost]
        public ActionResult AddOrEdit(Product prd)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if(prd.id == 0)
                    {
                        db.Products.Add(prd);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(prd).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = false, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllProduct()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }

            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}