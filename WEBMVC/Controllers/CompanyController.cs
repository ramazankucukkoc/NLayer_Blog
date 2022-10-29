using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results.ComplexTypes;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using WEBMVC.Models;

namespace WEBMVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }



        public async Task<IActionResult> Index()
        {
            var result = await _companyService.GetAllByNonDeleted();
            return View(result.Data);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CompanyAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(CompanyAddDto companyAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _companyService.Add(companyAddDto, "Ramazan Küçükkoç");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CompanyAddAjaxModel
                    {
                        CompanyDto = result.Data,
                        CompanyAddPartial = await this.RenderViewToStringAsync("_CompanyAddPartial", companyAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CompanyAddAjaxModel
            {
                CompanyAddPartial = await this.RenderViewToStringAsync("_CompanyAddPartial", companyAddDto)
            });
            return Json(categoryAddAjaxErrorModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int companyId)
        {
            var result = await _companyService.GetCategoryUpdate(companyId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_CategoryUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(CompanyUpdateDto companyUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _companyService.Update(companyUpdateDto, "Ramazan Küçükkoç");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var categoryUpdateAjaxModel = JsonSerializer.Serialize(new CompanyUpdateAjaxModel
                    {
                        CompanyDto = result.Data,
                        CompanyUpdatePartial = await this.RenderViewToStringAsync("_CompanyUpdatePartial", companyUpdateDto)
                    });
                    return Json(categoryUpdateAjaxModel);
                }
            }
            var categoryUpdateAjaxErrorModel = JsonSerializer.Serialize(new CompanyAddAjaxModel
            {
                CompanyAddPartial = await this.RenderViewToStringAsync("_CompanyUpdatePartial", companyUpdateDto)
            });
            return Json(categoryUpdateAjaxErrorModel);
        }
        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _companyService.GetAllByNonDeleted();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int companyId)
        {
            var result = await _companyService.Delete(companyId, "Ramazan Küçükkoç");
            var deletedCategory = JsonSerializer.Serialize(result.Data);
            return Json(deletedCategory);
        }
    }
}
