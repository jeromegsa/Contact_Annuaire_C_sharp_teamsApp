using Azure.Core;
using Azure.Identity;
using contact_annuaire.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.TeamsFx;

namespace contact_annuaire.Services
{
    public class SharePointService
    {
        private readonly IConfiguration _configuration;
        private readonly TeamsUserCredential _teamsUserCredential;

        private const string SiteHostname = "iokeo.sharepoint.com";
        private const string SitePath = "/sites/Training_site";
        private const string ListName = "annuaire_liste";
        private const string Scope = "Sites.ReadWrite.All";

        public SharePointService(IConfiguration configuration, TeamsUserCredential teamsUserCredential)
        {
            _configuration = configuration;
            _teamsUserCredential = teamsUserCredential;
        }

        // ===== Créer le client Graph =====
        private async Task<GraphServiceClient> GetGraphClientAsync()
        {
            var config = _configuration.Get<ConfigOptions>();
            var tenantId = config.TeamsFx.Authentication.OAuthAuthority
                .Remove(0, "https://login.microsoftonline.com/".Length);

            AccessToken ssoToken = await _teamsUserCredential.GetTokenAsync(
                new TokenRequestContext(null), new CancellationToken());

            var credential = new OnBehalfOfCredential(
                tenantId,
                config.TeamsFx.Authentication.ClientId,
                config.TeamsFx.Authentication.ClientSecret,
                ssoToken.Token
            );

            return new GraphServiceClient(credential, new[] { Scope });
        }

        // ===== Récupérer le site =====
        private async Task<string> GetSiteIdAsync(GraphServiceClient graph)
        {
            // Version compatible avec toutes les versions du SDK Graph
            var site = await graph.Sites[$"{SiteHostname}:{SitePath}"].GetAsync();
            return site.Id;
        }

        // ===== Récupérer l'Id de la liste =====
        private async Task<string> GetListIdAsync(GraphServiceClient graph, string siteId)
        {
            var lists = await graph.Sites[siteId].Lists.GetAsync();
            var liste = lists.Value.FirstOrDefault(l => l.Name == ListName);
            return liste?.Id;
        }

        // ===== LIRE tous les contacts =====
        public async Task<List<contact_annuaire.Models.Contact>> GetContactsAsync()
        {
            var graph = await GetGraphClientAsync();
            var siteId = await GetSiteIdAsync(graph);
            var listId = await GetListIdAsync(graph, siteId);

            var items = await graph.Sites[siteId]
                .Lists[listId]
                .Items
                .GetAsync(config =>
                {
                    config.QueryParameters.Expand = new[] { "fields" };
                });

            var contacts = new List<contact_annuaire.Models.Contact>();
            foreach (var item in items.Value)
            {
                var fields = item.Fields.AdditionalData;
                contacts.Add(new contact_annuaire.Models.Contact
                {
                    Id = int.TryParse(item.Id, out int id) ? id : 0,
                    Prenom = fields.ContainsKey("Title") ? fields["Title"]?.ToString() : "",
                    Nom = fields.ContainsKey("nom") ? fields["nom"]?.ToString() : "",
                    Email = fields.ContainsKey("email") ? fields["email"]?.ToString() : "",
                    Telephone = fields.ContainsKey("telephone") ? fields["telephone"]?.ToString() : ""
                });
            }
            return contacts;
        }

        // ===== AJOUTER un contact =====
        public async Task AjouterContactAsync(contact_annuaire.Models.Contact contact)
        {
            var graph = await GetGraphClientAsync();
            var siteId = await GetSiteIdAsync(graph);
            var listId = await GetListIdAsync(graph, siteId);

            await graph.Sites[siteId]
                .Lists[listId]
                .Items
                .PostAsync(new ListItem
                {
                    Fields = new FieldValueSet
                    {
                        AdditionalData = new Dictionary<string, object>
                        {
                            { "Title", contact.Prenom },
                            { "nom", contact.Nom },
                            { "email", contact.Email },
                            { "telephone", contact.Telephone }
                        }
                    }
                });
        }

        // ===== MODIFIER un contact =====
        public async Task ModifierContactAsync(contact_annuaire.Models.Contact contact)
        {
            var graph = await GetGraphClientAsync();
            var siteId = await GetSiteIdAsync(graph);
            var listId = await GetListIdAsync(graph, siteId);

            await graph.Sites[siteId]
                .Lists[listId]
                .Items[contact.Id.ToString()]
                .Fields
                .PatchAsync(new FieldValueSet
                {
                    AdditionalData = new Dictionary<string, object>
                    {
                        { "Title", contact.Prenom },
                        { "nom", contact.Nom },
                        { "email", contact.Email },
                        { "telephone", contact.Telephone }
                    }
                });
        }

        // ===== SUPPRIMER un contact =====
        public async Task SupprimerContactAsync(string itemId)
        {
            var graph = await GetGraphClientAsync();
            var siteId = await GetSiteIdAsync(graph);
            var listId = await GetListIdAsync(graph, siteId);

            await graph.Sites[siteId]
                .Lists[listId]
                .Items[itemId]
                .DeleteAsync();
        }

    // Ajoute cette méthode dans SharePointService.cs
    public async Task DemanderConsentementAsync()
        {
            await _teamsUserCredential.LoginAsync("Sites.ReadWrite.All");
        }
    } 
}