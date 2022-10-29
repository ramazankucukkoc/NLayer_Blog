using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results.ComplexTypes;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WEBMVC.Models;

namespace WEBMVC.Controllers
{
    public class CustomerTransactionController : Controller
    {
        private readonly ICustomerTrasanctionService _customerTrasanctionService;

        public CustomerTransactionController(ICustomerTrasanctionService customerTrasanctionService)
        {
            _customerTrasanctionService = customerTrasanctionService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _customerTrasanctionService.GetAllByNonDeleted();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CustomerTransactionAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(CustomerTransactionAddDto customerTransactionAddDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _customerTrasanctionService.Add(customerTransactionAddDto, "Ramazan Küçükkoç");
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var customerTransactionAddAjaxModel = JsonSerializer.Serialize(new CustomerTransactionAddAjaxModel
                    {
                        CustomerTransactionDto = result.Data,
                        CustomerTransactionAddPartial = await this.RenderViewToStringAsync("_CustomerTransactionAddPartial", customerTransactionAddDto)
                    });
                    return Json(customerTransactionAddAjaxModel);
                }
            }
            var customerTransactionAddAjaxErrorModel = JsonSerializer.Serialize(new CustomerTransactionAddAjaxModel
            {
                CustomerTransactionAddPartial = await this.RenderViewToStringAsync("_CustomerTransactionAddPartial", customerTransactionAddDto)

            });
            return Json(customerTransactionAddAjaxErrorModel);
        }
        public async Task<JsonResult> GetAllCustomerTransactions()
        {
            var result = await _customerTrasanctionService.GetAllByNonDeleted();
            var customerTransactions = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            });
            return Json(customerTransactions);
        }
    }
}
