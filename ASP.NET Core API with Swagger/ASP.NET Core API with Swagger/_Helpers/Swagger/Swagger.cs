using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;

namespace ASP.NET_Core_API_with_Swagger._Helpers.Swagger
{
    public static class Swagger
    {

        internal static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                // Adds the "token" parameter in the request header, to authorize access to the APIs
                config.OperationProcessors.Add(new AddRequiredHeaderParameter());

                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Title";
                    document.Info.Description = "Description";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Company Name",
                        Email = "mail@mail",
                        Url = "https://company.com.br"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });
        }

        internal static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enables the middleware to serve the generated Swagger as a JSON terminal.
            app.UseSwagger();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalUiRoute, request) =>
            {
                if (internalUiRoute.StartsWith("/") == true && internalUiRoute.StartsWith(request.PathBase) == false)
                {
                    return request.PathBase + internalUiRoute;
                }
                else
                {
                    return internalUiRoute;
                }
            });
        }

    }
}
