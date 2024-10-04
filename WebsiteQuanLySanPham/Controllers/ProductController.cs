using Microsoft.AspNetCore.Mvc;
using WebsiteQuanLySanPham.Models;

namespace WebsiteQuanLySanPham.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            QuanLySanPhamContext context = new QuanLySanPhamContext();
            List<Product> dsProduct = context.Products.ToList();  
            return View(dsProduct);
        }
    }
}
