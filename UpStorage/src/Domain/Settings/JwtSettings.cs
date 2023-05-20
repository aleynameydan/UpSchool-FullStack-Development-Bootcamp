namespace Domain.Settings;

public class JwtSettings
{
    //Jwtleri kitlediğimiz şifre
    public string SecretKey { get; set; }
    
    //kim oluşturdu?
    public string Issuer { get; set; }
    
    //kim için oluşturuldu? kim kullanacak?
    public string Audience { get; set; }
    
    //son kullanma tarihi 
    public int ExpiryInMinutes { get; set; }
}