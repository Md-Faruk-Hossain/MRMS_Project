using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightIssuesController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<FlightIssue> _flightIssueRepo;

        public FlightIssuesController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._flightIssueRepo = _globalRepo.FlightIssueRepository;
        }
        // Get FlightIssue
        [HttpGet]
        public IEnumerable<FlightIssue> GetFlightIssues()
        {
            return _flightIssueRepo.GetAll();
        }
        // Insert FlightIssue
        [HttpPost]
        public IActionResult PostFlightIssue(FlightIssue flightIssue)
        {
            _flightIssueRepo.Insert(flightIssue);
            _globalRepo.Save();
            return Ok(flightIssue);
        }
        // Update FlightIssue
        [HttpPut]
        public IActionResult PutFlightIssue(FlightIssue flightIssue)
        {
            if (flightIssue.FlightIssueId == 0)
            {
                return NotFound();
            }
            _flightIssueRepo.Update(flightIssue);
            _globalRepo.Save();
            return Ok(flightIssue);
        }
        // Delete FlightIssue
        [HttpDelete]
        public IActionResult DeleteFlightIssue(int id)
        {
            FlightIssue flightIssue = _flightIssueRepo.Get(id);
            if (flightIssue == null)
            {
                return NotFound();
            }
            _flightIssueRepo.Delete(flightIssue);
            _globalRepo.Save();
            return Ok(flightIssue);
        }
    }
}
