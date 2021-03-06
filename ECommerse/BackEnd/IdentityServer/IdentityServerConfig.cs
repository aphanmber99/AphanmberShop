using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace BackEnd.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                    new ApiScope("rookieshop.api", "Rookie Shop API")
             };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { Startup.ClientUrls["mvc"]+ "/signin-oidc" },

                    PostLogoutRedirectUris = { Startup.ClientUrls["mvc"]+"/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieshop.api"
                    }
                },
                   new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris =           { $"https://backend19e581e1a3fc4593a4e56901eb69aedb.azurewebsites.net/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"https://backend19e581e1a3fc4593a4e56901eb69aedb.azurewebsites.net/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"https://backend19e581e1a3fc4593a4e56901eb69aedb.azurewebsites.net" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rookieshop.api"
                    }
                },
            };
    }
}