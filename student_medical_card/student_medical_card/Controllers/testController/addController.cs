using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Service.MedicineServ.Interfaces;
using student_medical_card.Service.TestServ.Interfaces;

namespace student_medical_card.Controllers.testController
{
    [Route("api/[controller]")]
    [ApiController]
    public class addController : ControllerBase
    {
        private readonly t_IAddServ _service;

        public addController(IConfiguration configuration, t_IAddServ service)
        {

            _service = service;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddTests")]
        public t_Response AddTests(Test t)
        {

            t_Response response = new t_Response();

            response = _service.t_add(t);
            return response;
        }
    }
}