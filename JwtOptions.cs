namespace Prospectos
{
    public record class JwtOptions(
         string Issuer,
         string Audience,
         string SigningKey,
         int ExpirationSeconds
     );
}
