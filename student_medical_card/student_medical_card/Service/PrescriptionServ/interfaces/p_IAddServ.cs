using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;

namespace student_medical_card.Service.PrescriptionRepo.interfaces
{
    public interface p_IAddServ
    {
        p_Response p_Add(SqlConnection connection, Prescription prescription);
    }
}
