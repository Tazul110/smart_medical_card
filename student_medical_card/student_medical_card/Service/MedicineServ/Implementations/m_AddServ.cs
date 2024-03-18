using student_medical_card.Models;
using student_medical_card.Models.LogIn;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.MedicineRepo.Interfaces;
using student_medical_card.Service.LogServ.Interfaces;
using student_medical_card.Service.MedicineServ.Interfaces;
using System.Text.Json;

namespace student_medical_card.Service.MedicineServ.Implementations
{
    public class m_AddServ : m_IAddServ
    {
        private readonly m_IAddRepo m_repo;
        private readonly ILogService _logService;
        public m_AddServ(m_IAddRepo _repo, ILogService logService)
        {
            m_repo = _repo;
            _logService = logService;
        }
        public m_Response m_add(Medicine medicine)
        {
            var log = new Log
            {
                ActionDate = DateTime.Now,
                ActionChanges = "Medicine " + medicine + "Successful",
                JsonPayload = JsonSerializer.Serialize(medicine),
                IsActive = true,
            };
            var logmsg = _logService.Createlog(log);
            return m_repo.AddMedicine(medicine);
        }
    }
}
