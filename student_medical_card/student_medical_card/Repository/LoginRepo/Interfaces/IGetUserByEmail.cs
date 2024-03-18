using Microsoft.Data.SqlClient;
using student_medical_card.Models.LogIn;

namespace student_medical_card.Repository.LoginRepo.Interfaces
{
    public interface IGetUserByEmail
    {
        User GetBy_Email(string email);
    }
}
