using student_medical_card.Models.LogIn;
using student_medical_card.Models.Responses;

namespace student_medical_card.Service.LoginServ.Interfaces
{
    public interface L_IAddUserServ
    {
        userResponse add(User user);
    }
}
