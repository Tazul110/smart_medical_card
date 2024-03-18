
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.PrescriptionRepo.Interfaces;
using student_medical_card.Repository.StudentRepo.Interfaces;
using student_medical_card.Service.LogServ.Interfaces;
using student_medical_card.Service.StudentServ.Interfaces;
using System.Text.Json;

namespace student_medical_card.Service.StudentServ.Implementations
{
    public class s_AddServ : s_IAddServ
    {
            private readonly s_IAddRepo s_IAddRepo;
        private readonly ILogService _logService;

        public s_AddServ(s_IAddRepo IAddRepo, ILogService logService)
        {
            s_IAddRepo = IAddRepo;
            _logService = logService;
        }
        public s_Response s_Add(SqlConnection connection, Student student)
        {
            var log = new Log
            {
                ActionDate = DateTime.Now,
                ActionChanges = "Student " + student + "Successful",
                JsonPayload = JsonSerializer.Serialize(student),
                IsActive = true,
            };
            var logmsg = _logService.Createlog(log);
            return s_IAddRepo.AddStudent(connection, student);
        }       
    
    }
}
