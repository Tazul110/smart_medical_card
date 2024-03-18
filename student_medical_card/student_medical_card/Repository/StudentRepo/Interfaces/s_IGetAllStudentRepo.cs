using Microsoft.Data.SqlClient;
using student_medical_card.Models.Responses;
using student_medical_card.Models;

namespace student_medical_card.Repository.StudentRepo.Interfaces
{
    public interface s_IGetAllStudentRepo
    {
        s_Response GetAllStudents();
    }
}
