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
           

            public p_addController( p_IAddServ service)
            {
               
                _service = service;
            }

        [Authorize]
        [HttpPost]
            [Route("AddPrescription")]
            public p_Response AddPrescription(Prescription prescription)
            {
                p_Response response = new p_Response();

                response = _service.p_Add(prescription);
                return response;
            }
        
    }
}
