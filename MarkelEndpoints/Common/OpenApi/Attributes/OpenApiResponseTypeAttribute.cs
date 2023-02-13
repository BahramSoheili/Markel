using System;
using System.Net;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

namespace Markel.CostomerService.Common.OpenApi.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public sealed class OpenApiResponseTypeAttribute : OpenApiResponseWithBodyAttribute
{
    public OpenApiResponseTypeAttribute(Type bodyType) : base(HttpStatusCode.OK, "application/json", bodyType)
    {
    }
}
