using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThiThucHanh.Models;

namespace ThiThucHanh.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly TestThContext db;
        public CustomerController(TestThContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var list = db.Customers.ToList();
            return View(list);
        }

        [HttpGet("AddNew")]
        public IActionResult AddNewCustomer()
        {
            return View();
        }

        [HttpPost("AddNew")]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("Update")]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            return View(customer);
        }

        [HttpPost("Update")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Update(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet("Delete")]
        public IActionResult DeleteCustomer(int customerId)
        {
            var customer = db.Customers.Find(customerId);

            if (customer != null)
                db.Customers.Remove(customer);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
