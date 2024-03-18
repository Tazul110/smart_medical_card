using student_medical_card.Models.Responses;
using student_medical_card.Models;

namespace student_medical_card.Repository.TestRepo.Interfaces
{
    public interface IAddRepo
    {
        t_Response AddTest(Test t);
    }
}
