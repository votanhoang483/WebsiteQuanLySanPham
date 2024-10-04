using Microsoft.AspNetCore.Mvc;
using WebsiteQuanLySanPham.Models;

namespace WebsiteQuanLySanPham.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            QuanLySanPhamContext context = new QuanLySanPhamContext();
            List<Catalog> dsCatalog = context.Catalogs.ToList();
            return View(dsCatalog);
        }
    }
}
