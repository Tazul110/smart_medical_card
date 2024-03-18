using student_medical_card.Models;
using student_medical_card.Repository.StudentRepo.Interfaces;
using student_medical_card.Service.StudentServ.Interfaces;

namespace student_medical_card.Service.StudentServ.Implementations
{
    public class s_GetServ: s_IGetServ
    {
        private readonly s_IGetRepo _ICrudGetById;
        public s_GetServ(s_IGetRepo iCrudGetById)
        {
            _ICrudGetById = iCrudGetById;
        }

        public Student sGetById(int s_Id)
        {
            return _ICrudGetById.GetById(s_Id);
        }

    }
}
