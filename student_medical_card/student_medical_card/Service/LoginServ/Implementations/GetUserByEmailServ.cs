using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.LogIn;
using student_medical_card.Repository.LoginRepo.Interfaces;
using student_medical_card.Service.LoginServ.Interfaces;
using student_medical_card.Service.LogServ.Implements;
using student_medical_card.Service.LogServ.Interfaces;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;

namespace student_medical_card.Service.LoginServ.Implementations
{
    public class GetUserByEmailServ : IGetUserByEmailServ
    {
        private readonly IGetUserByEmail _user;
        private readonly ILogService _logService;
        public GetUserByEmailServ(IGetUserByEmail user,ILogService logService)
        {
            _user = user;
            _logService = logService;
        }
        public User AuthenticateUser(string email)
        {
            var log = new Log
            {
                ActionDate = DateTime.Now,
                ActionChanges = "AuthenticateUser " + email + "Successful",
                JsonPayload = JsonSerializer.Serialize(email),
                IsActive = true,
            };
            var logmsg = _logService.Createlog(log);
            return _user.GetBy_Email(email);
        }
    }
}
