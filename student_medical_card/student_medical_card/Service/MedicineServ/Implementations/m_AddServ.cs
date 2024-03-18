using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.MedicineRepo.Interfaces;
using student_medical_card.Service.MedicineServ.Interfaces;

namespace student_medical_card.Service.MedicineServ.Implementations
{
    public class m_AddServ : m_IAddServ
    {
        private readonly m_IAddRepo m_repo;
        public m_AddServ(m_IAddRepo _repo)
        {
            m_repo = _repo;
        }
        public m_Response m_add(Medicine medicine)
        {
            return m_repo.AddMedicine(medicine);
        }
    }
}
