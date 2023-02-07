using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.ApplicationSection;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<Calling> _callingRepo;
        
        public CallingsController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._callingRepo = _globalRepo.CallingRepository;
        }
        // Get Calling
        [HttpGet]
        public IEnumerable<Calling> GetCallings()
        {
            return _callingRepo.GetAll();
        }
        // Insert Calling
        [HttpPost]
        public IActionResult PostCalling(Calling calling)
        {
            _callingRepo.Insert(calling);
            _globalRepo.Save();
            return Ok(calling);
        }
        // Update Calling
        [HttpPut]
        public IActionResult PutCalling(Calling calling)
        {
            if (calling.CallingId == 0)
            {
                return NotFound();
            }
            _callingRepo.Update(calling);
            _globalRepo.Save();
            return Ok(calling);
        }
        // Delete Calling
        [HttpDelete]
        public IActionResult DeleteCalling(int id)
        {
            Calling  calling = _callingRepo.Get(id);
            if (calling == null)
            {
                return NotFound();
            }
            _callingRepo.Delete(calling);
            _globalRepo.Save();
            return Ok(calling);
        }
    }
}
