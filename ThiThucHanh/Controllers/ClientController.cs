using Microsoft.AspNetCore.Mvc;
using ThiThucHanh.Models;

namespace ThiThucHanh.Controllers
{
    public class ClientController : Controller
    {
        private readonly TestThContext db;

        public ClientController(TestThContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var spList = db.Products.ToList();
            return View(spList);
        }

        public IActionResult ViewDetails(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
    }
}
