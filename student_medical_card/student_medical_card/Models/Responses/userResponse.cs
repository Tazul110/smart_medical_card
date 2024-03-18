using student_medical_card.Models.LogIn;

namespace student_medical_card.Models.Responses
{
    public class userResponse
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }

        public User? User { get; set; }

        public List<User>? listUsers { get; set; }
    }
}
