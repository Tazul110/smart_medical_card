using Dapper;
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.LogIn;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.LoginRepo.Interfaces;

namespace student_medical_card.Repository.LoginRepo.Implementations
{
    public class L_AddUserRepo : L_IAddUserRepo
    {
        private readonly IConfiguration _configuration;
        public L_AddUserRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public userResponse AddUser(User user)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            userResponse L_response = new userResponse();



            int i = connection.Execute("INSERT INTO Users (userName, userEmail, userPassword) VALUES (@userName, @userEmail, @userPassword)", user);


            if (i > 0)
            {

                L_response.StatusCode = 200;
                L_response.StatusMessage = "User added.";
                L_response.User = user;

            }
            else
            {
                L_response.StatusCode = 100;
                L_response.StatusMessage = "No Data inserted";


            }
            return L_response;
        }
    }
}
