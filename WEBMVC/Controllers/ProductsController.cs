using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results.ComplexTypes;
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
            var result = await _productService.GetAllByNonDeleted();

            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
           
            return PartialView("_ProductAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
          

            if (ModelState.IsValid)
            {
                var result = await _productService.Add(productAddDto, "Ramazan Küçükkoç");
                if (result.ResultStatus == ResultStatus.Success)
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

        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            var result = await _productService.GetProductUpdate(productId);
           
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_ProductUpdatePartial", result.Data);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            //var result2 = await _categoryService.GetAllByNonDeleted();
            //ViewBag.categories = new SelectList(result2.Data.Categories, "Id", "Name", productUpdateDto.CategoryId);
            if (ModelState.IsValid)
            {
                var result = await _productService.Update(productUpdateDto, "Ramazan KÜÇÜKKOÇ");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var productUpdateAjaxModel = JsonSerializer.Serialize(new ProductUpdateAjaxModel
                    {
                        ProductDto = result.Data,
                        ProductUpdatePartial = await this.RenderViewToStringAsync("_ProductUpdatePartial", productUpdateDto)
                    });
                    return Json(productUpdateAjaxModel);

                }
            }
            var productUpdateAjaxErrorModel = JsonSerializer.Serialize(new ProductUpdateAjaxModel
            {
                ProductUpdatePartial = await this.RenderViewToStringAsync("_ProductUpdatePartial", productUpdateDto)
            });
            return Json(productUpdateAjaxErrorModel);

        }

        public async Task<JsonResult> GetAllProducts()
        {
            var result = await _productService.GetAllByNonDeleted();
            var products = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(products);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int productId)
        {
            var result = await _productService.Delete(productId, "Ramazan Küçükkoç");
            var deleteProduct = JsonSerializer.Serialize(result.Data);
            return Json(deleteProduct);

        }

    }
}
