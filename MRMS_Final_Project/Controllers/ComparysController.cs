using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.CommonSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComparysController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<Company> _comparyRepo;

        public ComparysController(IGlobalRepository globalRepo)
        {
            this._globalRepo = globalRepo;
            this._comparyRepo = _globalRepo.CompanyRepository;
        }
        // Get Company
        [HttpGet]
        public IEnumerable<Company> GetCompanies()
        {
            return _comparyRepo.GetAll();
        }
        // Insert Company
        [HttpPost]
        public IActionResult PostCompany(Company company)
        {
            _comparyRepo.Insert(company);
            _globalRepo.Save();
            return Ok(company);
        }
        // Update Company
        [HttpPut]
        public IActionResult PutCompany(Company company)
        {
            if (company.CompanyId == 0)
            {
                return NotFound();
            }
            _comparyRepo.Update(company);
            _globalRepo.Save();
            return Ok(company);
        }
        // Delete Company
        [HttpDelete]
        public IActionResult DeleteCompany(int id)
        {
            Company company = _comparyRepo.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            _comparyRepo.Delete(company);
            _globalRepo.Save();
            return Ok(company);
        }
    }
}
