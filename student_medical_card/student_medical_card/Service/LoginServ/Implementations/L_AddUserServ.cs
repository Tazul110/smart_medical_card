using student_medical_card.Models;
using student_medical_card.Models.LogIn;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.LoginRepo.Interfaces;
using student_medical_card.Service.LoginServ.Interfaces;
using student_medical_card.Service.LogServ.Interfaces;
using System.Text.Json;

namespace student_medical_card.Service.LoginServ.Implementations
{
    public class L_AddUserServ : L_IAddUserServ
    {
        private readonly L_IAddUserRepo _repo;
        private readonly ILogService _logService;
        public L_AddUserServ(L_IAddUserRepo repo,ILogService logService)
        {
            _repo = repo;
            _logService = logService;
        }
        public userResponse add(User user)
        {
            var log = new Log
            {
                ActionDate = DateTime.Now,
                ActionChanges = "Login " + user + "Successful",
                JsonPayload = JsonSerializer.Serialize(user),
                IsActive = true,
            };
            var logmsg = _logService.Createlog(log);
            return _repo.AddUser(user);
        }
    }
}
