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
    public class DepartmanController : Controller
    {
        private readonly IDepartmanService _departmanService;

        public DepartmanController(IDepartmanService departmanService)
        {
            _departmanService = departmanService;
        }

        public async Task<IActionResult> Index()
        {
            var departmans = await _departmanService.GetAllByNonDeleted();
            return View(departmans.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_DepartmanAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmanAddDto departmanAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _departmanService.Add(departmanAddDto, "Ramazan Küçükkoç");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var departmanAddAjaxModel = JsonSerializer.Serialize(new DepartmanAddAjaxModel
                    {
                        DepartmanDto = result.Data,
                        DepartmanAddPartial = await this.RenderViewToStringAsync("_DepartmanAddPartial", departmanAddDto)
                    });
                    return Json(departmanAddAjaxModel);
                }
            }
            var departmanAddAjaxErrorModel = JsonSerializer.Serialize(new DepartmanAddAjaxModel
            {
                DepartmanAddPartial = await this.RenderViewToStringAsync("_DepartmanAddPartial", departmanAddDto)
            });
            return Json(departmanAddAjaxErrorModel);
        }
        public async Task<JsonResult> GetAllDepartmans()
        {
            var result = await _departmanService.GetAllByNonDeleted();
            var departmans = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(departmans);
        }
    }
}
