using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingFilesController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<CallingFile> _callingFileRepo;

        public CallingFilesController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._callingFileRepo = _globalRepo.CallingFileRepository;
        }
        // Get CallingFile
        [HttpGet]
        public IEnumerable<CallingFile> GetCallings()
        {
            return _callingFileRepo.GetAll();
        }
        // Insert CallingFile
        [HttpPost]
        public IActionResult PostCallingFile(CallingFile callingFile)
        {
            _callingFileRepo.Insert(callingFile);
            _globalRepo.Save();
            return Ok(callingFile);
        }
        // Update CallingFile
        [HttpPut]
        public IActionResult PutCalling(CallingFile callingFile)
        {
            if (callingFile.CallingFileId == 0)
            {
                return NotFound();
            }
            _callingFileRepo.Update(callingFile);
            _globalRepo.Save();
            return Ok(callingFile);
        }
        // Delete CallingFile
        [HttpDelete]
        public IActionResult DeleteCallingFile(int id)
        {
            CallingFile  callingFile = _callingFileRepo.Get(id);
            if (callingFile == null)
            {
                return NotFound();
            }
            _callingFileRepo.Delete(callingFile);
            _globalRepo.Save();
            return Ok(callingFile);
        }
    }
}
