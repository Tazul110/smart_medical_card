using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Service.PrescriptionRepo.interfaces;
using student_medical_card.Service.MedicineServ.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace student_medical_card.Controllers.medicineController
{
    [Route("api/")]
    [ApiController]
    public class m_addController : ControllerBase
    {
        private readonly m_IAddServ _service;
        
        public m_addController(IConfiguration configuration, m_IAddServ service)
        {
           
            _service = service;
        }

        [Authorize]
        [HttpPost]
        [Route("AddMedicine")]
        public m_Response AddMedicines(Medicine medicine)
        {
            
            m_Response response = new m_Response();

            response = _service.m_add( medicine);
            return response;
        }
    }
}
