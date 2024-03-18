using student_medical_card.Models;
using student_medical_card.Models.Responses;

namespace student_medical_card.Service.TestServ.Interfaces
{
    public interface t_IAddServ
    {
        t_Response t_add(Test t);
    }
}
