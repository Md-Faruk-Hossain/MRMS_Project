using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CommonSection;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<Flight> _flightRepo;

        public FlightsController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._flightRepo = _globalRepo.FlightRepository;
        }
        // Get Flight
        [HttpGet]
        public IEnumerable<Flight> GetFlights()
        {
            return _flightRepo.GetAll();
        }
        // Insert Flight
        [HttpPost]
        public IActionResult PostFlight(Flight flight)
        {
            _flightRepo.Insert(flight);
            _globalRepo.Save();
            return Ok(flight);
        }
        // Update Flight
        [HttpPut]
        public IActionResult PutFlight(Flight flight)
        {
            if (flight.FlightId == 0)
            {
                return NotFound();
            }
            _flightRepo.Update(flight);
            _globalRepo.Save();
            return Ok(flight);
        }
        // Delete Flight
        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            Flight flight = _flightRepo.Get(id);
            if (flight == null)
            {
                return NotFound();
            }
            _flightRepo.Delete(flight);
            _globalRepo.Save();
            return Ok(flight);
        }
    }
}
