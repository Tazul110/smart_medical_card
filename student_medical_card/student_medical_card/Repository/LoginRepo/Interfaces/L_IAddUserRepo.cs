using student_medical_card.Models.LogIn;
using student_medical_card.Models.Responses;

namespace student_medical_card.Repository.LoginRepo.Interfaces
{
    public interface L_IAddUserRepo
    {
        userResponse AddUser(User user);
    }
}
