using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.Json.Serialization;
using WEBMVC.Models;

namespace WEBMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService) 
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var result=await _productService.GetAllByNonDeleted();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_ProductAddPartial");
        }
        [HttpPost]
        public async Task <IActionResult> Add(ProductAddDto productAddDto)
        {
            var categoryList=await _categoryService.GetAllByNonDeleted();
            ViewBag.categories = new SelectList(categoryList.Data.ToString(), "Id", "Name");
            if (ModelState.IsValid)
            {
                var result = await _productService.Add(productAddDto, "Ramazan Küçükkoç");
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var productAddAjaxModel = JsonSerializer.Serialize(new ProductAddAjaxModel
                    {
                        ProductDto = result.Data,
                        ProductAddPartial = await this.RenderViewToStringAsync("_ProductAddPartial", productAddDto)
                    });
                    return Json(productAddAjaxModel);
                }
            }
            var productAddAjaxErrorModel = JsonSerializer.Serialize(new ProductAddAjaxModel
            {
                ProductAddPartial = await this.RenderViewToStringAsync("_ProductAddPartial", productAddDto)
            });
            return Json(productAddAjaxErrorModel);
        }
        public async Task<IActionResult> GetAllProducts()
        {
            var result=await _productService.GetAllByNonDeleted();
            var products = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            }) ;
            return Json(products);
        }

    }
}
