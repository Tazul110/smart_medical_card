
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.PrescriptionRepo.Interfaces;
using student_medical_card.Repository.StudentRepo.Interfaces;
using student_medical_card.Service.StudentServ.Interfaces;

namespace student_medical_card.Service.StudentServ.Implementations
{
    public class s_AddServ : s_IAddServ
    {
            private readonly s_IAddRepo s_IAddRepo;

        public s_AddServ(s_IAddRepo IAddRepo)
        {
            s_IAddRepo = IAddRepo;
        }
        public s_Response s_Add(SqlConnection connection, Student student)
        {
            return s_IAddRepo.AddStudent(connection, student);
        }       
    
    }
}
