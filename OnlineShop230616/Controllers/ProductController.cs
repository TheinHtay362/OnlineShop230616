using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineShop230616.DAL;
using OnlineShop230616.Models;

namespace OnlineShop230616.Controllers
{
    public class ProductController : Controller
    {
        private readonly OnlineShopDbContext _dbContext;
        public ProductController(OnlineShopDbContext context)
        {
            _dbContext = context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();
            products = _dbContext.product.ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductModel model = new ProductModel();
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.product.Add(model);
                    _dbContext.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            // Retrieve product from the database 
            try
            {
                var product = _dbContext.product.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel product)
        {
            if (id != product.Id)
            {
                return NotFound(); // If the id from the route doesn't match the id of the product, return a 404 Not Found page or handle it as desired
            }

            // Check if the model is valid
            if (ModelState.IsValid)
            {
                try
                {
                    // Update the product in the database
                    _dbContext.Entry(product).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Exception handling for concurrency conflicts (if the product was modified by another user since it was loaded)
                    // You can choose to handle this in a way that suits your application (e.g., display an error message, redirect to a different page, etc.)
                    return NotFound();
                }
            }
            return RedirectToAction("Index"); // Redirect to the index page or any other desired action
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
