using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CommonSection;
using MRMS.Model.DemandSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<DemandIssueComment> _demandIssueCommentRepo;

        public DemandIssueCommentsController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._demandIssueCommentRepo = _globalRepo.DemandIssueCommentRepository;
        }
        // Get DemandIssueComment
        [HttpGet]
        public IEnumerable<DemandIssueComment> GetCountries()
        {
            return _demandIssueCommentRepo.GetAll();
        }
        // Insert DemandIssueComment
        [HttpPost]
        public IActionResult PostDemandIssueComment(DemandIssueComment demandIssueComment)
        {
            _demandIssueCommentRepo.Insert(demandIssueComment);
            _globalRepo.Save();
            return Ok(demandIssueComment);
        }
        // Update DemandIssueComment
        [HttpPut]
        public IActionResult PutDemanIssueComment(DemandIssueComment  demandIssueComment)
        {
            if (demandIssueComment.DemandIssueCommentId == 0)
            {
                return NotFound();
            }
            _demandIssueCommentRepo.Update(demandIssueComment);
            _globalRepo.Save();
            return Ok(demandIssueComment);
        }
        // Delete DemandIssueComment
        [HttpDelete]
        public IActionResult DeleteDemandIssueComment(int id)
        {
            DemandIssueComment demandIssueComment = _demandIssueCommentRepo.Get(id);
            if (demandIssueComment == null)
            {
                return NotFound();
            }
            _demandIssueCommentRepo.Delete(demandIssueComment);
            _globalRepo.Save();
            return Ok(demandIssueComment);
        }
    }
}
