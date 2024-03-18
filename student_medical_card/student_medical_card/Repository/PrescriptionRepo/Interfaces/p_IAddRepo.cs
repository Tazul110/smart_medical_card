using student_medical_card.Models.Responses;
using student_medical_card.Models;
using Microsoft.Data.SqlClient;

namespace student_medical_card.Repository.PrescriptionRepo.Interfaces
{
    public interface p_IAddRepo
    {
        p_Response AddPrescription(SqlConnection connection, Prescription prescription);
    }
}
