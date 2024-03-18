using student_medical_card.Models;
using student_medical_card.Models.Responses;

namespace student_medical_card.Service.MedicineServ.Interfaces
{
    public interface m_IAddServ
    {
        m_Response m_add(Medicine medicine);

    }
}
