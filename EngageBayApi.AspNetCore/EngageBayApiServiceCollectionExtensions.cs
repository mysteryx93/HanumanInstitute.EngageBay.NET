using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using HanumanInstitute.EngageBayApi;
using HanumanInstitute.EngageBayApi.Models;

// ReSharper disable once CheckNamespace - MS guidelines say put DI registration in this NS
namespace Microsoft.Extensions.DependencyInjection;

public static class EngageApiServiceCollectionExtensions
{
    /// <summary>
    /// Registers EngageApi classes into the IoC container.
    /// </summary>
    /// <param name="services">The IoC services container.</param>
    public static IServiceCollection AddEngageApi(this IServiceCollection services) =>
        AddEngageApi(services, null);

    /// <summary>
    /// Registers EngageApi classes into the IoC container.
    /// </summary>
    /// <param name="services">The IoC services container.</param>
    /// <param name="additionalHttpConfig">Additional configuration to be applied to HttpClient connections.</param>
    public static IServiceCollection AddEngageApi(this IServiceCollection services, Action<IHttpClientBuilder>? additionalHttpConfig)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var ontraClient = services.AddHttpClient<EngageHttpClient>();
        var formsClient = services.AddHttpClient<IEngagePostForms, EngagePostForms>();
        if (additionalHttpConfig != null)
        {
            additionalHttpConfig(ontraClient);
            additionalHttpConfig(formsClient);
        }

        services.TryAddTransient<IEngageBroadcasts, EngageBroadcasts>();
        services.TryAddTransient<IEngageCompanies, EngageCompanies>();
        services.TryAddTransient<IEngageContacts, EngageContacts>();
        services.TryAddTransient<IEngageCustomFields, EngageCustomFields>();
        services.TryAddTransient<IEngageDeals, EngageDeals>();
        services.TryAddTransient<IEngageForms, EngageForms>();
        services.TryAddTransient<IEngageProducts, EngageProducts>();
        services.TryAddTransient<IEngageTags, EngageTags>();
        services.TryAddTransient<IEngageTasks, EngageTasks>();
        services.TryAddTransient<IEngageTracks, EngageTracks>();
        services.TryAddTransient<IEngageUsers, EngageUsers>();

        return services;
    }

    /// <summary>
    /// Registers only EngageApi classes to post forms, without adding the API.
    /// </summary>
    /// <param name="services">The IoC services container.</param>
    public static IServiceCollection AddEngagePostForms(this IServiceCollection services) =>
        AddEngagePostForms(services, null);

    /// <summary>
    /// Registers only EngageApi classes to post forms, without adding the API.
    /// </summary>
    /// <param name="services">The IoC services container.</param>
    /// <param name="additionalHttpConfig">Additional configuration to be applied to HttpClient connections.</param>
    public static IServiceCollection AddEngagePostForms(this IServiceCollection services, Action<IHttpClientBuilder>? additionalHttpConfig)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        var ontraClient = services.AddHttpClient<EngageHttpClient>();
        var formsClient = services.AddHttpClient<IEngagePostForms, EngagePostForms>();
        additionalHttpConfig?.Invoke(formsClient);

        return services;
    }
}
