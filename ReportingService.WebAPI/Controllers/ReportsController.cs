using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportingService.WebAPI.Data;
using ReportingService.WebAPI.Services;

namespace ReportingService.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("{reportId}")]
        public async Task<IActionResult> Get(int reportId)
        {
            var report = (await _reportsService.Get(new[] { reportId })).FirstOrDefault();
            if (report == null)
                return NotFound("Report");

            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Report report)
        {
            await _reportsService.Add(report);
            return Ok(report);
        }
    }
}
