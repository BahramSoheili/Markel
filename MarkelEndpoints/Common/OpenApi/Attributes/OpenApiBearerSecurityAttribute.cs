using System;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace Markel.CostomerService.Common.OpenApi.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public sealed class OpenApiBearerSecurityAttribute : OpenApiSecurityAttribute
{
    public OpenApiBearerSecurityAttribute() : base("bearer_auth", SecuritySchemeType.Http)
    {
        this.Scheme = OpenApiSecuritySchemeType.Bearer;
        this.BearerFormat = "JWT";
        this.Description = "Past JWT without word 'Bearer'!";
    }
}
