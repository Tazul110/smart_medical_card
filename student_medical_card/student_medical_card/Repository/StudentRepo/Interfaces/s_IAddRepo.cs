using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;

namespace student_medical_card.Repository.StudentRepo.Interfaces
{
    public interface s_IAddRepo
    {
        s_Response AddStudent(SqlConnection connection, Student student);
    }
}
