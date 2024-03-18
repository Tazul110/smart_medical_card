using Microsoft.Data.SqlClient;
using student_medical_card.Models.Responses;
using student_medical_card.Models;

namespace student_medical_card.Service.StudentServ.Interfaces
{
    public interface s_IAddServ
    {
        s_Response s_Add(SqlConnection connection,Student student);
    }
}
