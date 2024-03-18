using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.MedicineRepo.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace student_medical_card.Repository.MedicineRepo.Implements
{
    public class m_AddRepo : m_IAddRepo
    {
        private readonly IConfiguration _configuration;
        public m_AddRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public m_Response AddMedicine(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection"));
            m_Response m_response = new m_Response();


            
            int i = connection.Execute("INSERT INTO Medicine2 (p_Id, m_Name, m_Type, consumption_Rule, m_Days) VALUES (@p_Id, @m_Name, @m_Type, @consumption_Rule, @m_Days)", medicine);


            if (i > 0)
            {

                m_response.StatusCode = 200;
                m_response.StatusMessage = "Medicine added.";
                m_response.Medicine  = medicine;

            }
            else
            {
                m_response.StatusCode = 100;
                m_response.StatusMessage = "No Data inserted";


            }
            return m_response;
        }
    }
}
