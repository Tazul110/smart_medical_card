using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using student_medical_card.Models.LogIn;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.LoginRepo.Interfaces;

namespace student_medical_card.Repository.LoginRepo.Implementations
{
    public class GetUserByEmail : IGetUserByEmail
    {
        private readonly IConfiguration _configuration;
        public GetUserByEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public User GetBy_Email(string email)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            userResponse lresponse =new userResponse();

            var user = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE userEmail = @userEmail", new { userEmail = email });

            if (user != null)
            {
                lresponse.StatusCode = 200;
                lresponse.StatusMessage = "Data found";
                lresponse.User = user;
            }
            else
            {
                lresponse.StatusCode = 100;
                lresponse.StatusMessage = "No Data found";
                lresponse.User = null;
            }

            return lresponse.User;
        }
    }
}
