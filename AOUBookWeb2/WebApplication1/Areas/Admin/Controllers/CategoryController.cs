using AOUBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using AOUBook.DataAccess.Data;
using AOUBook.Models;
using Microsoft.AspNetCore.Authorization;
using AOUBook.Utility;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using AutoMapper;

namespace AOUBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        //private readonly string _apiUrl = "https://localhost:7200/api/Category";
        public CategoryController(IUnitOfWork unitOfWork, HttpClient httpClient, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task <IActionResult> Index()
        {
            var endpoint = _configuration.GetSection("AppSettings:ApiUrl").Value;
            var response = await _httpClient.GetAsync($"{endpoint}/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
                return View(categories);
            }
            else
            {
                //Handle error response
                //List<CategoryViewModel> objCategoryList = _unitOfWork.Category.GetAll().Select(x => new CategoryViewModel
                //{
                //    Id = x.Id,
                //    Name = x.Name,
                //    DisplayOrder = x.DisplayOrder
                //}).ToList();
                return View(new List<CategoryViewModel>());
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order can not be same");
            }

            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(obj);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var endpoint = _configuration.GetSection("AppSettings:ApiUrl").Value;
                var response = await _httpClient.PostAsync($"{endpoint}/api/Category", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the category.");
                }
            }
            return View();
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public async Task <IActionResult> Edit(Category obj)
        {


            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(obj);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var endpoint = _configuration.GetSection("AppSettings:ApiUrl").Value;
                var request = new HttpRequestMessage(HttpMethod.Put, $"{endpoint}/api/Category/{obj.Id}")
                {
                    Content = content
                };
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Category updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the category.");
                }

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public async Task <IActionResult> DeletePOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var endpoint = _configuration.GetSection("AppSettings:ApiUrl").Value;
            var response = await _httpClient.DeleteAsync($"{endpoint}/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the category.");
                return View();
            }
        }
    }
}
