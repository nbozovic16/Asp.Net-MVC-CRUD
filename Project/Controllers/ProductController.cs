using Project.Models;
using System;
using System.Collections.Generic;
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
            return View(prd);
        }

        [HttpPost]
        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}