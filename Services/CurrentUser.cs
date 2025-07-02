namespace UniBazaarLite.Services
{
    // Simüle edilmiş kullanıcı bilgilerini tutan servis
    public class CurrentUser
    {
        public string Email { get; set; } = "admin@unibazaar.com";
        public bool IsAuthenticated { get; set; } = true;  // true ise giriş yapılmış sayılır
    }
}
