namespace uploading_image.models
{
    public interface APIResponseFormat
    {
        int ResponseCode { get; set; }
        string Result { get; set; }
        string Errormessage { get; set; }
    }
}
