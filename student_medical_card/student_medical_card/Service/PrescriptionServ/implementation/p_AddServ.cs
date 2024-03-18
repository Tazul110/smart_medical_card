using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.PrescriptionRepo.Interfaces;
using student_medical_card.Service.PrescriptionRepo.interfaces;

namespace student_medical_card.Service.PrescriptionServ.implementation
{
    public class p_AddServ : p_IAddServ
    {
        private readonly p_IAddRepo p_IAddRepo;

        public p_AddServ(p_IAddRepo IAddRepo)
        {
            p_IAddRepo=IAddRepo;
        }
        public p_Response p_Add(SqlConnection connection, Prescription prescription)
        {
            return p_IAddRepo.AddPrescription(connection, prescription);
        }
    }
}
