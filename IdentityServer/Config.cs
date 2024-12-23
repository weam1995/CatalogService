using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
                { 
                new ApiScope("catalogApi", "Catalog API")
                };

        public static IEnumerable<Client> Clients =>
            new Client[]
                {
                       new() {
                            ClientId = "bd7fe5d7-289f-4828-9786-4fa4e34426e8",
                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            ClientSecrets = { new Secret("client_secret".Sha256()) },
                            AllowedScopes = { "catalogApi" }
                        },
                       new() {
                            ClientId = "69f01650-edfd-4b6c-a243-6c45bd316040",
                            AllowedGrantTypes = GrantTypes.Code,
                            ClientSecrets = { new Secret("client_secret".Sha256()) },
                            RedirectUris = { "https://localhost:5002/signin-oidc" },
                            // where to redirect to after logout
                            PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                            AllowOfflineAccess = true,
                            AllowedScopes =
                            {
                                IdentityServerConstants.StandardScopes.OpenId,
                                IdentityServerConstants.StandardScopes.Profile,
                                "catalogApi",
                            }
                        },

                };
    }
}