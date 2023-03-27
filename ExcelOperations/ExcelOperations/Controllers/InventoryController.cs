using Microsoft.AspNetCore.Mvc;

namespace ExcelOperations.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
