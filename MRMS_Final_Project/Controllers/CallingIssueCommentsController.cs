using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<CallingIssueComment> _callingIssueCommentRepo;

        public CallingIssueCommentsController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._callingIssueCommentRepo = _globalRepo.CallingIssueCommentRepository;
        }
        // Get CallingIssueComment
        [HttpGet]
        public IEnumerable<CallingIssueComment> GetCallingIssueComments()
        {
            return _callingIssueCommentRepo.GetAll();
        }
        // Insert CallingIssueComment
        [HttpPost]
        public IActionResult PostCallingIssueComment(CallingIssueComment callingIssueComment)
        {
            _callingIssueCommentRepo.Insert(callingIssueComment);
            _globalRepo.Save();
            return Ok(callingIssueComment);
        }
        // Update CallingIssueComment
        [HttpPut]
        public IActionResult PutCallingIssueComment(CallingIssueComment callingIssueComment)
        {
            if (callingIssueComment.CallingIssueCommentId == 0)
            {
                return NotFound();
            }
            _callingIssueCommentRepo.Update(callingIssueComment);
            _globalRepo.Save();
            return Ok(callingIssueComment);
        }
        // Delete CallingIssueComment
        [HttpDelete]
        public IActionResult DeleteCallingIssueComment(int id)
        {
            CallingIssueComment callingIssueComment = _callingIssueCommentRepo.Get(id);
            if (callingIssueComment == null)
            {
                return NotFound();
            }
            _callingIssueCommentRepo.Delete(callingIssueComment);
            _globalRepo.Save();
            return Ok(callingIssueComment);
        }
    }
}
