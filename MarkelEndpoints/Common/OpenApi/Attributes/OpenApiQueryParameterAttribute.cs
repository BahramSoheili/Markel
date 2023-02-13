using System;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;

namespace Markel.CostomerService.Common.OpenApi.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class OpenApiQueryParameterAttribute : OpenApiParameterAttribute
{
    public OpenApiQueryParameterAttribute(string name, Type type, bool required = false) : base(name)
    {
        this.Type = type;
        this.In = ParameterLocation.Query;
        this.Required = required;
    }
}
