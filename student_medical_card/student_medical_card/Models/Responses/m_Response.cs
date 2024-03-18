namespace student_medical_card.Models.Responses
{
    public class m_Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Medicine? Medicine { get; set; }

        public List<Medicine>? listMedicine { get; set; }
    }
}
