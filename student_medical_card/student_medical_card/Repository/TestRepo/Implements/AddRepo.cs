using Dapper;
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.TestRepo.Interfaces;

namespace student_medical_card.Repository.TestRepo.Implements
{
    public class AddRepo : IAddRepo
    {
        private readonly IConfiguration _configuration;
        public AddRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public t_Response AddTest(Test t)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            t_Response t_response = new t_Response();



            int i = connection.Execute("INSERT INTO Test2 (p_Id, t_Name ) VALUES (@p_Id, @t_Name)", t);


            if (i > 0)
            {

                t_response.StatusCode = 200;
                t_response.StatusMessage = "Test added.";
                t_response.Test = t;

            }
            else
            {
                t_response.StatusCode = 100;
                t_response.StatusMessage = "No Data inserted";


            }
            return t_response;
        }
    }
}
