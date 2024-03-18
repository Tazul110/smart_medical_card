using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.logRepo.Interfaces;
using student_medical_card.Service.LogServ.Interfaces;

namespace student_medical_card.Service.LogServ.Implements
{
    public class LogService : ILogService
    {
        private readonly ILogRepo _logRepo;
        public LogService(ILogRepo logRepo) 
        {  
            _logRepo = logRepo;
        }
        public async Task<LogResponse> Createlog(Log log)
        {
            try
            {
                var res = await _logRepo.Createlog(log);
                var response = new LogResponse();

                if (res != 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Log Successfully Created";
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Unsuccessful to Create Log";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
