namespace student_medical_card.Models.Responses
{
    public class s_Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Student? Student { get; set; }

        public List<Student>? listStudent { get; set; }
    }
}
