#region Using Directives

using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;

#endregion

public abstract class AzureDevOpsService
{
    #region Fields

    protected readonly HttpClient _httpClient;
    protected readonly string? _organizationName;
    protected readonly string? _projectName;
    protected readonly string? _azureUrl;

    #endregion

    #region Constructors

    protected AzureDevOpsService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _azureUrl = configuration["AzureDevOps:AzureUrl"];
        _organizationName = configuration["AzureDevOps:OrganizationName"];
        _projectName = configuration["AzureDevOps:ProjectName"];

        // var personalAccessToken = Environment.GetEnvironmentVariable("AZURE_DEVOPS_PAT");
        var personalAccessTokenTFS = Environment.GetEnvironmentVariable("TFS_PAT");

        if (string.IsNullOrEmpty(personalAccessTokenTFS))
        {
            throw new InvalidOperationException("Your Environment Variable: AZURE_DEVOPS_PAT - Personal Access Token cannot be null or empty.");
        }

        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($":{personalAccessTokenTFS}")));
    }

    #endregion
}