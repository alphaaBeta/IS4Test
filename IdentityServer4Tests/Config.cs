using IdentityServer4.Models;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace IdentityServer4withRSA
{
    public class Config
    {
        public static string ADDomain => ConfigurationManager.AppSettings["AD.Domain"];
        public static string ApiId => ConfigurationManager.AppSettings["Api.Identifier"];
        public static string ApiSecret => ConfigurationManager.AppSettings["Api.Secret"];
        public static string ClientId => ConfigurationManager.AppSettings["Client.Identifier"];
        public static string ClientSecret => ConfigurationManager.AppSettings["Client.Secret"];

        public static string ISAddress => ConfigurationManager.AppSettings["IS.Ip"];
        public static string ISPort => ConfigurationManager.AppSettings["IS.Port"];

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource(ApiId)
                {
                    ApiSecrets = { new Secret(ApiSecret.Sha256()) }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // resource owner password grant client
                new Client
                {
                    ClientId = ClientId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret(ClientSecret.Sha256())
                    },
                    AllowedScopes = { ApiId }
                }
            };
        }

        
    }
}