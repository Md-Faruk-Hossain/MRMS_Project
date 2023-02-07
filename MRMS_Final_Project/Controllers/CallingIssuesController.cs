using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingIssuesController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<CallingIssue> _callingIssueRepo;

        public CallingIssuesController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._callingIssueRepo = _globalRepo.CallingIssueRepository;
        }
        // Get CallingIssue
        [HttpGet]
        public IEnumerable<CallingIssue> GetCallingIssues()
        {
            return _callingIssueRepo.GetAll();
        }
        // Insert CallingIssue
        [HttpPost]
        public IActionResult PostCallingIssue(CallingIssue callingIssue)
        {
            _callingIssueRepo.Insert(callingIssue);
            _globalRepo.Save();
            return Ok(callingIssue);
        }
        // Update CallingIssue
        [HttpPut]
        public IActionResult PutCallingIssue(CallingIssue callingIssue)
        {
            if (callingIssue.CallingIssueId == 0)
            {
                return NotFound();
            }
            _callingIssueRepo.Update(callingIssue);
            _globalRepo.Save();
            return Ok(callingIssue);
        }
        // Delete CallingIssue
        [HttpDelete]
        public IActionResult DeleteCallingIssue(int id)
        {
            CallingIssue callingIssue = _callingIssueRepo.Get(id);
            if (callingIssue == null)
            {
                return NotFound();
            }
            _callingIssueRepo.Delete(callingIssue);
            _globalRepo.Save();
            return Ok(callingIssue);
        }
    }
}
