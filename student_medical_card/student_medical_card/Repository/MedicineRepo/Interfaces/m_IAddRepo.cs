using Microsoft.Data.SqlClient;
using student_medical_card.Models.Responses;
using student_medical_card.Models;

namespace student_medical_card.Repository.MedicineRepo.Interfaces
{
    public interface m_IAddRepo
    {
        m_Response AddMedicine(Medicine medicine);
    }
}
