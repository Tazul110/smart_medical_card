namespace student_medical_card.Models.Responses
{
    public class p_Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public Prescription? Prescription { get; set; }

        public List<Prescription>? listPrescription { get; set; }
    }
}
