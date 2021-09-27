namespace BusinessLogic.Helpers
{
    public class AppSettings
    {
        public string DatabaseConnection { get; set; }
        public string JwtToken { get; set; }
        public GoogleConfig GoogleConfig { get; set; }
        public string ApiToPdfToken { get; set; }
    }
}