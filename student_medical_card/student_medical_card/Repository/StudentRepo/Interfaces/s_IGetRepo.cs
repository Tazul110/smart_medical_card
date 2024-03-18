using student_medical_card.Models;

namespace student_medical_card.Repository.StudentRepo.Interfaces
{
    public interface s_IGetRepo
    {
        Student GetById(int s_Id);
    }
}
