using Microsoft.AspNetCore.Mvc;
using ThiThucHanh.Models;

namespace ThiThucHanh.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly TestThContext db;
        public ProductController(TestThContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var list = db.Products.ToList();
            return View(list);
        }

        [HttpGet("AddNew")]
        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost("AddNew")]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Update")]
        public IActionResult UpdateProduct(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [HttpPost("Update")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet("Delete")]
        public IActionResult DeleteProduct(int productId)
        {
            var product = db.Products.Find(productId);

            if (product != null)
                db.Products.Remove(product);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
