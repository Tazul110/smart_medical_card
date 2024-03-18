
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using student_medical_card.Models;
using student_medical_card.Repository.StudentRepo.Interfaces;


namespace student_medical_card.Repository.StudentRepo.Implements
{
    public class s_GetRepo : s_IGetRepo
    {
        private readonly IConfiguration _configuration;

        public s_GetRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Student GetById(int s_Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection")))
            {
                connection.Open();

                var query = @"
               
                    SELECT s.s_Id, s.s_Name, s.s_Dept, s.s_Gender, s.s_Email, s.b_Date,
                    p.p_Id, p.s_Id, p.health_condition, p.prescribeBy, p.prescribe_date_time,
                    m.m_Id, m.p_Id, m.m_Name, m.m_Type, m.consumption_Rule, m.m_Days
                    FROM Student2 s
                    LEFT JOIN Prescription2 p ON s.s_Id = p.s_Id
                    LEFT JOIN Medicine2 m ON p.p_Id = m.p_Id
                    WHERE s.s_Id = @s_Id
                    ORDER BY p.p_Id";



                var studentPrescriptionDictionary = new Dictionary<int, Student>();

                var result = connection.Query<Student, Prescription, Medicine, Student>(
                    query,
                    (student, prescription, medicine) =>
                    {
                        if (!studentPrescriptionDictionary.TryGetValue(student.s_Id, out var studentPrescription))
                        {
                            studentPrescription = student;
                            studentPrescription.listPrescription = new List<Prescription>();
                            studentPrescriptionDictionary.Add(student.s_Id, studentPrescription);
                        }

                        if (prescription != null)
                        {
                            var existingPrescription = studentPrescription.listPrescription
                                .FirstOrDefault(p => p.p_Id == prescription.p_Id);

                            if (existingPrescription == null)
                            {
                                prescription.listMedicine = prescription.listMedicine ?? new List<Medicine>();
                                prescription.listMedicine.Add(medicine); // Add medicine to the prescription
                                studentPrescription.listPrescription.Add(prescription);
                            }
                            else
                            {
                                // Prescription already exists, just add the medicine to it
                                existingPrescription.listMedicine = existingPrescription.listMedicine ?? new List<Medicine>();
                                existingPrescription.listMedicine.Add(medicine);
                            }
                        }

                        return studentPrescription;
                    },
                    new { s_Id },
                    splitOn: "p_Id, m_Id"
                ).Distinct();

                return result.FirstOrDefault();
            }
        }
    }
}