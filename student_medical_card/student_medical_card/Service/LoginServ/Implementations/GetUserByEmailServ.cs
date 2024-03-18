using Microsoft.Data.SqlClient;
using student_medical_card.Models.LogIn;
using student_medical_card.Repository.LoginRepo.Interfaces;
using student_medical_card.Service.LoginServ.Interfaces;

namespace student_medical_card.Service.LoginServ.Implementations
{
    public class GetUserByEmailServ : IGetUserByEmailServ
    {
        private readonly IGetUserByEmail _user;
        public GetUserByEmailServ(IGetUserByEmail user)
        {
            _user = user;
        }
        public User AuthenticateUser(string email)
        {
            return _user.GetBy_Email(email);
        }
    }
}
