using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.TestRepo.Interfaces;
using student_medical_card.Service.TestServ.Interfaces;

namespace student_medical_card.Service.TestServ.Implements
{
    public class t_AddServ : t_IAddServ
    {
        private readonly IAddRepo _repo;
        public t_AddServ(IAddRepo repo)
        {
            _repo = repo;
        }
        public t_Response t_add(Test t)
        {
            return _repo.AddTest(t);
        }
    }
}
