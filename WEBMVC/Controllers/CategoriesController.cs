using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WEBMVC.Models;

namespace WEBMVC.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAll();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
        //[HttpPost]
        //public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _categoryService.Add(categoryAddDto, "Ramazan Küçükkoç");
        //        if (result.ResultStatus==Core.Utilities.Results.ComplexTypes.ResultStatus.Success)
        //        {
        //            var categoryAddModel = JsonSerializer.Serialize(new CategoryAddAjaxModel
        //            {
        //                CategoryDto = result.Data
        //            }) ;
        //        }

        //    }

        //}

    }
}
