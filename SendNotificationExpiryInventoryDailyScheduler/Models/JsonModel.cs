namespace SendNotificationExpiryInventoryDailyScheduler.Models
{
    public class JsonModel
    {
        public string access_token;
        public int expires_in;
        public object UserPermission { get; set; }
        public object AppConfigurations { get; set; }
        public object UserLocations { get; set; }
        public object data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string AppError { get; set; }
        public string UserRole { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string PhotoBase64 { get; set; }
        public string EncryptedId { get; set; }
        public int Id { get; set; }
    }
}
