using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<FlightIssueComment> _flightIssueCommentRepo;

        public FlightIssueCommentsController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._flightIssueCommentRepo = _globalRepo.FlightIssueCommentRepository;
        }
        // Get FlightIssueComment
        [HttpGet]
        public IEnumerable<FlightIssueComment> GetFlightIssueComments()
        {
            return _flightIssueCommentRepo.GetAll();
        }
        // Insert FlightIssueComment
        [HttpPost]
        public IActionResult PostFlightIssueComment(FlightIssueComment  flightIssueComment)
        {
            _flightIssueCommentRepo.Insert(flightIssueComment);
            _globalRepo.Save();
            return Ok(flightIssueComment);
        }
        // Update FlightIssueComment
        [HttpPut]
        public IActionResult PutFlightIssueComment(FlightIssueComment flightIssueComment)
        {
            if (flightIssueComment.FlightIssueCommentId == 0)
            {
                return NotFound();
            }
            _flightIssueCommentRepo.Update(flightIssueComment);
            _globalRepo.Save();
            return Ok(flightIssueComment);
        }
        // Delete FlightIssueComment
        [HttpDelete]
        public IActionResult DeleteFlightIssueComment(int id)
        {
            FlightIssueComment flightIssueComment = _flightIssueCommentRepo.Get(id);
            if (flightIssueComment == null)
            {
                return NotFound();
            }
            _flightIssueCommentRepo.Delete(flightIssueComment);
            _globalRepo.Save();
            return Ok(flightIssueComment);
        }
    }
}
