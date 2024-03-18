using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Service.StudentServ.Interfaces;

namespace student_medical_card.Controllers.studentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class s_addController : ControllerBase
    {
        private readonly s_IAddServ _service;
        private readonly IConfiguration _configuration;

        public s_addController(IConfiguration configuration, s_IAddServ service)
        {
            _configuration = configuration;
            _service = service;
        }

        //[Authorize]
        [HttpPost]
        [Route("AddStudent")]
        public s_Response AddStudent(Student student)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            s_Response response = new s_Response();

            response = _service.s_Add(connection, student);
            return response;
        }
    }
}
