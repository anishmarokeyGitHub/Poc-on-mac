namespace UserManagement.IdentityServer
{
    public class BasicClientConfig
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string[] AllowedScopes { get; set; }
    }
}