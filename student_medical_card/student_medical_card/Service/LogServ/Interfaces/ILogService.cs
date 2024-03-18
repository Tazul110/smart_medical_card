using student_medical_card.Models;
using student_medical_card.Models.Responses;

namespace student_medical_card.Service.LogServ.Interfaces
{
    public interface ILogService
    {
        Task<LogResponse> Createlog(Log log);
    }
}
