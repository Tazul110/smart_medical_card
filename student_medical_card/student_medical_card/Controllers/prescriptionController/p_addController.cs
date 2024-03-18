using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Service.PrescriptionRepo.interfaces;

namespace student_medical_card.Controllers.prescriptionController
{
    [Route("api/")]
    [ApiController]
    public class p_addController : ControllerBase
    {
       
            private readonly p_IAddServ _service;
            private readonly IConfiguration _configuration;

            public p_addController(IConfiguration configuration, p_IAddServ service)
            {
                _configuration = configuration;
                _service = service;
            }

        [Authorize]
        [HttpPost]
            [Route("AddPrescription")]
            public p_Response AddPrescription(Prescription prescription)
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
                p_Response response = new p_Response();

                response = _service.p_Add(connection, prescription);
                return response;
            }
        
    }
}
