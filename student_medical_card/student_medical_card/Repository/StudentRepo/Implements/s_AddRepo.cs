using Dapper;
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Models.Responses;
using student_medical_card.Repository.StudentRepo.Interfaces;

namespace student_medical_card.Repository.StudentRepo.Implements
{
    public class s_AddRepo:s_IAddRepo
    {
        public s_Response AddStudent(SqlConnection connection, Student student)
        {
            s_Response s_response = new s_Response();


            //int i = connection.Execute("INSERT INTO student2 (s_Id, s_Name, s_Dept, s_Gender, s_Email, b_Date) VALUES (@s_Id, @s_Name, @s_Dept, @s_Gender, @s_Email, @b_Date)", student);
            int i = connection.Execute("INSERT INTO student2 (s_Id, s_Name, s_Dept, s_Gender, s_Email, b_Date, s_Image) VALUES (@s_Id, @s_Name, @s_Dept, @s_Gender, @s_Email, @b_Date, @s_Image)", student);

            if (i > 0)
            {

                s_response.StatusCode = 200;
                s_response.StatusMessage = "Student added.";
                s_response.Student = student;

            }
            else
            {
                s_response.StatusCode = 100;
                s_response.StatusMessage = "No Data inserted";


            }
            return s_response;
        }
        
    }
}
