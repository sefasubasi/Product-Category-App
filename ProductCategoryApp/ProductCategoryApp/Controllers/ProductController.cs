namespace ProductCategoryApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProductCategoryApp.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            await _productService.LoadCategoriesAsync();
            var categories = _productService.GetCategories();
            return View(categories);
        }

        public async Task<IActionResult> Category(string slug)
        {
            var allowedCategories = new List<string>
        {
            "beauty", "fragrances", "furniture", "groceries",
            "home-decoration", "kitchen-accessories", "laptops"
        };

            if (!allowedCategories.Contains(slug.ToLower()))
            {
                return NotFound();
            }

            var products = await _productService.GetProductsByCategoryAsync(slug);
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            ViewBag.CategoryName = slug;
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDetails(string category, int id)
        {
            // Belirli bir kategoriden ürünleri çekiyoruz
            var products = await _productService.GetProductsByCategoryAsync(category);
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Json(product);
        }

    }



}
