using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.ApplicantSection;
using MRMS.Model.CommonSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<ApplicantIssueComment> _applicantIssueCommentsRepo;
        public ApplicantIssueCommentsController(IGlobalRepository globalRepository)
        {
                this._globalRepo = globalRepository;
            this._applicantIssueCommentsRepo = _globalRepo.ApplicantIssueCommentRepository;
        }
        //Get ApplicantIssueComment
        [HttpGet]
        public IEnumerable<ApplicantIssueComment> GetApplicantIssueComments()
        {
            return _applicantIssueCommentsRepo.GetAll();
        }
        // Post ApplicantIssueComment
        [HttpPost]
        public IActionResult PastApplicantIssueComment(ApplicantIssueComment applicantIssueComment)
        {
            _applicantIssueCommentsRepo.Insert(applicantIssueComment);
            _globalRepo.Save();
            return Ok(applicantIssueComment);
        }
        //Update ApplicantIssueComment
        [HttpPut]
        public IActionResult UpdateApplicantIssueComment(ApplicantIssueComment  applicantIssueComment)
        {
            if (applicantIssueComment.ApplicantIssueCommentId == 0)
            {
                return NotFound();
            }
            _applicantIssueCommentsRepo.Update(applicantIssueComment);
            _globalRepo.Save();
            return Ok(applicantIssueComment);
        }

        //Delete ApplicantIssueComment
        [HttpDelete("{id}")]
        public IActionResult DeleteApplicantIssueComment(int id)
        {
            ApplicantIssueComment applicantIssueComment  = _applicantIssueCommentsRepo.Get(id);
            if (applicantIssueComment == null)
            {
                return NotFound();
            }

            _applicantIssueCommentsRepo.Delete(applicantIssueComment);
            _globalRepo.Save();
            return Ok(applicantIssueComment);
        }

    }
}
