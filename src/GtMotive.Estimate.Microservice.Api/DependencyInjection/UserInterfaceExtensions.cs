using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddSingleton<GetVehiclesPresenter>();
            services.AddScoped<IGetVehiclesPresenter, GetVehiclesPresenter>();
            services.AddScoped<IGetVehiclesOutputPort, GetVehiclesPresenter>();

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehiclePresenter, CreateVehiclePresenter>();
            services.AddScoped<IOutputPortStandard<CreateVehicleOutput>>(sp => sp.GetService<CreateVehiclePresenter>());

            return services;
        }
    }
}
