using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
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
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryAddDto, "Alper Tunga");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxModel
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
            });
            return Json(categoryAddAjaxErrorModel);

        }

    }
}
