using System;
using NSwag;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System.Threading.Tasks;

namespace ASP.NET_Core_API_with_Swagger._Helpers.Swagger
{
public class AddRequiredHeaderParameter : IOperationProcessor
{

    public Task<bool> ProcessAsync(OperationProcessorContext context)
    {
        context.OperationDescription.Operation.Parameters.Add(
        new SwaggerParameter
        {
            Name = "token",
            Kind = SwaggerParameterKind.Header,
            Type = NJsonSchema.JsonObjectType.String,
            IsRequired = false,
            Description = "Description_Value",
            Default = "Default_Value"
        });

        return Task.FromResult(true);
    }
}
}
