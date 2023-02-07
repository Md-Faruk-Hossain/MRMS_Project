using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CallingSection;
using MRMS.Model.CommonSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<Country> _countryRepo;

        public CountrysController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._countryRepo = _globalRepo.CountryRepository;
        }
        // Get Country
        [HttpGet]
        public IEnumerable<Country> GetCountries()
        {
            return _countryRepo.GetAll();
        }
        // Insert Country
        [HttpPost]
        public IActionResult PostCountry(Country country)
        {
            _countryRepo.Insert(country);
            _globalRepo.Save();
            return Ok(country);
        }
        // Update Country
        [HttpPut]
        public IActionResult PutCountry(Country country)
        {
            if (country.CountryId == 0)
            {
                return NotFound();
            }
            _countryRepo.Update(country);
            _globalRepo.Save();
            return Ok(country);
        }
        // Delete Country
        [HttpDelete]
        public IActionResult DeleteCountry(int id)
        {
            Country country = _countryRepo.Get(id);
            if (country == null)
            {
                return NotFound();
            }
            _countryRepo.Delete(country);
            _globalRepo.Save();
            return Ok(country);
        }
    }
}
