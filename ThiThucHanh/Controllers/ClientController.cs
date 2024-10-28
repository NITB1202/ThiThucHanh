using Microsoft.AspNetCore.Mvc;

namespace ThiThucHanh.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
