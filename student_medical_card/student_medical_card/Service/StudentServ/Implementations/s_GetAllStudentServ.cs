using student_medical_card.Models.Responses;
using student_medical_card.Repository.StudentRepo.Interfaces;
using student_medical_card.Service.StudentServ.Interfaces;

namespace student_medical_card.Service.StudentServ.Implementations
{
    public class s_GetAllStudentServ : s_IGetAllStudentServ
    {
        private readonly s_IGetAllStudentRepo _repo;
        public s_GetAllStudentServ(s_IGetAllStudentRepo repo)
        {
            _repo = repo;
        }

        public s_Response Get()
        {
            return _repo.GetAllStudents();
        }
    }
}
