using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CallingSection;
using MRMS.Model.RejectSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RejectedApplicantsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<RejectedApplicant> _rejectedApplicantRepo;

        public RejectedApplicantsController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._rejectedApplicantRepo = _globalRepo.RejectedApplicantRepository;
        }
        // Get RejectedApplicant
        [HttpGet]
        public IEnumerable<RejectedApplicant> GetRejectedApplicants()
        {
            return _rejectedApplicantRepo.GetAll();
        }
        // Insert RejectedApplicant
        [HttpPost]
        public IActionResult PostRejectedApplicant(RejectedApplicant rejectedApplicant)
        {
            _rejectedApplicantRepo.Insert(rejectedApplicant);
            _globalRepo.Save();
            return Ok(rejectedApplicant);
        }
        // Update RejectedApplicant
        [HttpPut]
        public IActionResult PutRejectedApplicant(RejectedApplicant rejectedApplicant)
        {
            if (rejectedApplicant.RejectedApplicantId == 0)
            {
                return NotFound();
            }
            _rejectedApplicantRepo.Update(rejectedApplicant);
            _globalRepo.Save();
            return Ok(rejectedApplicant);
        }
        // Delete RejectedApplicant
        [HttpDelete]
        public IActionResult DeleteRejectedApplicant(int id)
        {
            RejectedApplicant rejectedApplicant = _rejectedApplicantRepo.Get(id);
            if (rejectedApplicant == null)
            {
                return NotFound();
            }
            _rejectedApplicantRepo.Delete(rejectedApplicant);
            _globalRepo.Save();
            return Ok(rejectedApplicant);
        }
    }
}
