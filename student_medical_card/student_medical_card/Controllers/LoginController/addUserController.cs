using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_medical_card.Models.Responses;
using student_medical_card.Models;
using student_medical_card.Service.MedicineServ.Interfaces;
using student_medical_card.Service.LoginServ.Interfaces;
using student_medical_card.Models.LogIn;

namespace student_medical_card.Controllers.LoginController
{
    [Route("api/")]
    [ApiController]
    public class addUserController : ControllerBase
    {
        private readonly L_IAddUserServ _serv;

        public addUserController(L_IAddUserServ serv)
        {

            _serv = serv;
        }


        [HttpPost]
        [Route("AddUser")]
        public userResponse AddUser(User user)
        {

            userResponse response = new userResponse();

            response = _serv.add(user);
            return response;
        }
    }
}
