using student_medical_card.Models.LogIn;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.LoginRepo.Interfaces;
using student_medical_card.Service.LoginServ.Interfaces;

namespace student_medical_card.Service.LoginServ.Implementations
{
    public class L_AddUserServ : L_IAddUserServ
    {
        private readonly L_IAddUserRepo _repo;
        public L_AddUserServ(L_IAddUserRepo repo)
        {
            _repo = repo;
        }
        public userResponse add(User user)
        {
            return _repo.AddUser(user);
        }
    }
}
