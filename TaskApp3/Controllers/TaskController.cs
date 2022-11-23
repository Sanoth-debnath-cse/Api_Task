using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskApp3.DTO;
using TaskApp3.IRepository;

namespace TaskApp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository )
        {
            _taskRepository = taskRepository;
        }
        [HttpPost]
        [Route("CreatePartnerType")]
     public async Task<IActionResult> CreatePartner(string typename)
        {
            var dt = await _taskRepository.CreatePartner(typename);
            return Ok(JsonConvert.SerializeObject(dt));
        }
        [HttpPost]
        [Route("CreateItems")]
        public async Task<IActionResult> CreateItems(List<ItemDTO> obj)
        {
            var dt = await _taskRepository.CreateItems(obj);
            return Ok(JsonConvert.SerializeObject(dt));
        }
        [HttpPut]
        [Route("EditItems")]
        public async Task<IActionResult> EditItems(int id, ItemDTO obj)
        {
            var dt =await _taskRepository.EditItems(id, obj);
            return Ok(JsonConvert.SerializeObject(dt));
        }
        [HttpPost]
        [Route("CreatePurchase")]
        public async Task<IActionResult> PurchaseItems(PurchaseCommonDTO obj,int itemid)
        {
            var dt =await _taskRepository.PurchaseItems(obj,itemid);
            return Ok(JsonConvert.SerializeObject(dt));
        }
        [HttpPost]
        [Route("SalesDetais")]
        public async Task<IActionResult> SalesItem(SalesCommonDTO obj, int itemid)
        {
            var dt =await _taskRepository.SalesItem(obj,itemid);
            return Ok(JsonConvert.SerializeObject(dt));
        }
        [HttpGet]
        [Route("PurchaseReport")]

        public async Task<IActionResult> PurchaseReport(int itemid)
        {
            var dt =  _taskRepository.PurchaseReport(itemid);
            return Ok(JsonConvert.SerializeObject(dt));

        }
        [HttpGet]
        [Route("SalesReport")]

        public async Task<IActionResult> SalesReport(int salesid, DateTime fromdate, DateTime todate)
        {
            var dt = _taskRepository.SalesReport(salesid, fromdate, todate);
            return Ok(JsonConvert.SerializeObject(dt));
        }
        [HttpGet]
        [Route("SalesReportMonthly")]

        public async Task<IActionResult> SalesReportMonthly(int salesid)
        {
            var dt = _taskRepository.SalesReportMonthly(salesid);
            return Ok(JsonConvert.SerializeObject(dt));
        }

        [HttpGet]
        [Route("PurchaseVSsales Report")]

        public async Task<IActionResult> purchaseVSsalesReports(int itemid)
        {
            var dt =_taskRepository.purchaseVSsalesReports(itemid);
            return Ok(JsonConvert.SerializeObject(dt));
        }

        [HttpGet]
        [Route("FinalReport")]

        public async Task<IActionResult> FinalReport(int itemid)
        {
            var dt = _taskRepository.FinalReport(itemid);
            return Ok(JsonConvert.SerializeObject(dt));
        }
    }

}
