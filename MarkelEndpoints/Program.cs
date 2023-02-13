using Google.Protobuf.WellKnownTypes;
using Markel.CostomerService.Common.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using MediatR;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(builder =>
    {
        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
        builder.Services.AddSwaggerGen();
    })
    .ConfigureServices(s =>
    {
        s.AddSingleton<ICompanyRepository, CompanyRepository>();

    })
    .Build();
