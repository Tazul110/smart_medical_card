namespace student_medical_card.Models.Responses
{
    public class t_Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Test? Test { get; set; }

        public List<Test>? listTest { get; set; }
    }
}
