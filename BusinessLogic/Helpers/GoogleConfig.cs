using Newtonsoft.Json;

namespace BusinessLogic.Helpers
{
    public class GoogleConfig
    {
        [JsonIgnore]
        public string CloudStorageBucket { get; set; }
        
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        
        [JsonProperty(PropertyName = "project_id")]
        public string ProjectId { get; set; }
        
        [JsonProperty(PropertyName = "private_key_id")]
        public string PrivateKeyId { get; set; }
        
        [JsonProperty(PropertyName = "private_key")]
        public string PrivateKey { get; set; }
        
        [JsonProperty(PropertyName = "client_email")]
        public string ClientEmail { get; set; }
        
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }
        
        [JsonProperty(PropertyName = "auth_uri")]
        public string AuthUri { get; set; }
        
        [JsonProperty(PropertyName = "token_uri")]
        public string TokenUri { get; set; }
        
        [JsonProperty(PropertyName = "auth_provider_x509_cert_url")]
        public string AuthProviderCertUrl { get; set; }
        
        [JsonProperty(PropertyName = "client_x509_cert_url")]
        public string ClientCertUrl { get; set; }
    }
}