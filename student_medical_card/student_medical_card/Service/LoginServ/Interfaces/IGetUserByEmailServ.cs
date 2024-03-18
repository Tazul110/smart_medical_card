using Microsoft.Data.SqlClient;
using student_medical_card.Models.LogIn;

namespace student_medical_card.Service.LoginServ.Interfaces
{
    public interface IGetUserByEmailServ
    {
        User AuthenticateUser(string email);
    }
}
