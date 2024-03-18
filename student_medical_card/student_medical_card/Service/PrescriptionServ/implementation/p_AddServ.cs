using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.PrescriptionRepo.Interfaces;
using student_medical_card.Service.LogServ.Interfaces;
using student_medical_card.Service.PrescriptionRepo.interfaces;
using System.Text.Json;

namespace student_medical_card.Service.PrescriptionServ.implementation
{
    public class p_AddServ : p_IAddServ
    {
        private readonly p_IAddRepo p_IAddRepo;
        private readonly ILogService _logService;

        public p_AddServ(p_IAddRepo IAddRepo, ILogService logService)
        {
            p_IAddRepo=IAddRepo;
            _logService = logService;
        }
        public p_Response p_Add( Prescription prescription)
        {
            var log = new Log
            {
                ActionDate = DateTime.Now,
                ActionChanges = "Prescription " + prescription + "Successful",
                JsonPayload = JsonSerializer.Serialize(prescription),
                IsActive = true,
            };
            var logmsg = _logService.Createlog(log);
            return p_IAddRepo.AddPrescription(prescription);
        }
    }
}
