using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using student_medical_card.Models.Responses;
using student_medical_card.Service.StudentServ.Interfaces;

namespace student_medical_card.Controllers.studentController
{
    [Route("api/")]
    [ApiController]
    public class s_getAllStudentController : ControllerBase
    {
        private readonly s_IGetAllStudentServ _Serv;

        public s_getAllStudentController(s_IGetAllStudentServ s)
        {
            _Serv = s;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public s_Response GetAll_Students()
        {
            s_Response response = new s_Response();

            response = _Serv.Get();
            return response;
        }
    }
}
