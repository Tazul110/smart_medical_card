using Dapper;
using Microsoft.Data.SqlClient;

using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.StudentRepo.Interfaces;


namespace student_medical_card.Repository.StudentRepo.Implements
{
    public class s_GetAllStudentRepo : s_IGetAllStudentRepo
    {
        private readonly IConfiguration _configuration;

        public s_GetAllStudentRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public s_Response GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            s_Response response = new s_Response();


            var lstStudents = connection.Query<Student>("SELECT * FROM Student2").ToList();

            if (lstStudents.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listStudent = lstStudents;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data found";
                response.listStudent = null;
            }

            return response;
        }
    }
}
