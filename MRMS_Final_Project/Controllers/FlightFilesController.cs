using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightFilesController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<FlightFile> _flightFileRepo;

        public FlightFilesController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._flightFileRepo = _globalRepo.FlightFileRepository;
        }
        // Get FlightFile
        [HttpGet]
        public IEnumerable<FlightFile> GetFlightFiles()
        {
            return _flightFileRepo.GetAll();
        }
        // Insert FlightFile
        [HttpPost]
        public IActionResult PostFlightFile(FlightFile flightFile)
        {
            _flightFileRepo.Insert(flightFile);
            _globalRepo.Save();
            return Ok(flightFile);
        }
        // Update FlightFile
        [HttpPut]
        public IActionResult PutFlightFile(FlightFile flightFile)
        {
            if (flightFile.FlightFileId == 0)
            {
                return NotFound();
            }
            _flightFileRepo.Update(flightFile);
            _globalRepo.Save();
            return Ok(flightFile);
        }
        // Delete Flight
        [HttpDelete]
        public IActionResult DeleteFlightFile(int id)
        {
            FlightFile flightFile = _flightFileRepo.Get(id);
            if (flightFile == null)
            {
                return NotFound();
            }
            _flightFileRepo.Delete(flightFile);
            _globalRepo.Save();
            return Ok(flightFile);
        }
    }
}
