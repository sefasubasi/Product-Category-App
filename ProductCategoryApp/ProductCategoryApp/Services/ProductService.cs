namespace ProductCategoryApp.Services
{
    using Newtonsoft.Json;
    using ProductCategoryApp.Models;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private List<Category> _categories;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Kategorileri cekme
        public async Task LoadCategoriesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://dummyjson.com/products/categories");
            _categories = JsonConvert.DeserializeObject<List<Category>>(response);
        }

        public List<Category> GetCategories() => _categories;

        // Belirli bir kategoriye göre ürünleri API'den çek
        public async Task<List<Product>> GetProductsByCategoryAsync(string categorySlug)
        {
            var response = await _httpClient.GetStringAsync($"https://dummyjson.com/products/category/{categorySlug}");
            var productsWrapper = JsonConvert.DeserializeObject<ProductsWrapper>(response);
            return productsWrapper.Products;
        }

    }

    public class ProductsWrapper
    {
        public List<Product> Products { get; set; }
    }




}
