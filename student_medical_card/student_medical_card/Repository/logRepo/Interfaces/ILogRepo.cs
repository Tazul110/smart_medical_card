using student_medical_card.Models;

namespace student_medical_card.Repository.logRepo.Interfaces
{
    public interface ILogRepo
    {
        Task<long> Createlog(Log log);
    }
}
