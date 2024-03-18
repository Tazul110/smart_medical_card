namespace uploading_image.models
{
    public class ApiResponse : APIResponseFormat
    {
        public int ResponseCode { get; set; }
        public string Result { get; set; }
        public string Errormessage { get; set; }

        
    }
}
