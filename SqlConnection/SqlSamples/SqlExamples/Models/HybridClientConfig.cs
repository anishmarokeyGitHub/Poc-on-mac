namespace UserManagement.IdentityServer
{
    public class HybridClientConfig
    {
        public string Id { get; set; }
        public string Host { get; set; }
        public string TenantId { get; set; }
        public string Secret { get; set; }
        public string[] AllowedScopes { get; set; }
        public string RegistrationUrl { get; set; }
        public string LoginTitle { get; set; }
        public string UsernameLabel { get; set; }
        public string ForgotPasswordLabel { get; set; }
        public string RegistrationLoginReturnUrl { get; set; }
        public string LoginBranding { get; set; }
        public string ExternalProvider { get; set; }
    }
}