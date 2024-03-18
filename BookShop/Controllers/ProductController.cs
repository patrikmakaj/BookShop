using BookShop.DataAccess.Data;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.Controllers
{
    public class ProductController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> productList = _unitOfWork.Product.GetAll().ToList();
            return View(productList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product, List<Product> productList)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product created succesfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Edit(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return NotFound();
            }
            Product? product = _unitOfWork.Product.Get(c => c.Id == productId);
            //Category? category1 = _context.Categories.Find(categoryId);
            //Category? category2 = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product edited successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Delete(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return NotFound();
            }
            Product? product = _unitOfWork.Product.Get(c => c.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? productId)
        {
            Product? product = _unitOfWork.Product.Get(c => c.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index", "Product");
        }
    }
}
