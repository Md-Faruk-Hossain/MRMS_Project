using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.ApplicationSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<ApplicationIssueComment> _applicationIssueCommentRepo;
        public ApplicationIssueCommentsController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._applicationIssueCommentRepo = _globalRepo.ApplicationIssueCommentRepository;
        }
        // Get ApplicationIssueComment
        [HttpGet]
        public IEnumerable<ApplicationIssueComment> GetApplicationIssueComments()
        {
            return _applicationIssueCommentRepo.GetAll();
        }
        // Insert ApplicationIssueComment
        [HttpPost]
        public IActionResult PostApplicationIssueComment(ApplicationIssueComment applicationIssueComment)
        {
            _applicationIssueCommentRepo.Insert(applicationIssueComment);
            _globalRepo.Save();
            return Ok(applicationIssueComment);
        }
        // Update ApplicationIssueComment
        [HttpPut]
        public IActionResult PutApplicationIssueComment(ApplicationIssueComment applicationIssueComment)
        {
            if(applicationIssueComment.ApplicationIssueCommentId==0)
            {
                return NotFound();
            }
            _applicationIssueCommentRepo.Update(applicationIssueComment);
            _globalRepo.Save();
            return Ok(applicationIssueComment);
        }
        // Delete ApplicationIssueComment
        [HttpDelete]
        public IActionResult DeleteApplicationIssueComment(int id)
        {
            ApplicationIssueComment applicationIssueComment = _applicationIssueCommentRepo.Get(id);
            if(applicationIssueComment == null)
            {
                return NotFound();
            }
            _applicationIssueCommentRepo.Delete(applicationIssueComment);
            _globalRepo.Save();
            return Ok(applicationIssueComment);
        }

    }
}
