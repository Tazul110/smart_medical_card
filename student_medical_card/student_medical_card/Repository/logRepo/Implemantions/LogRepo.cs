using Dapper;
using Microsoft.Data.SqlClient;
using student_medical_card.Models;
using student_medical_card.Repository.logRepo.Interfaces;
using System;

namespace student_medical_card.Repository.logRepo.Implemantions
{
    public class LogRepo : ILogRepo
    {
        private readonly IConfiguration _configuration;
        public LogRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<long> Createlog(Log log)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection")))
                {
                    await connection.OpenAsync();
                    var query = @"INSERT INTO log 
                                (ActionDate
                                ,ActionChanges
                                ,JsonPayload
                                ,IsActive) 
                                 VALUES 
                                 (@ActionDate
                                 ,@ActionChanges
                                 ,@JsonPayload
                                 ,@IsActive)";
                    var res = await connection.ExecuteAsync(query, log);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Something went wrong. Please contact the administrator.");
            }
        }
    }
}