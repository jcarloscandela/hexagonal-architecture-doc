using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateRental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<GetVehiclesPresenter>();
            services.AddScoped<IGetVehiclesPresenter>(sp => sp.GetService<GetVehiclesPresenter>());
            services.AddScoped<IGetVehiclesOutputPort>(sp => sp.GetService<GetVehiclesPresenter>());

            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehiclePresenter>(sp => sp.GetService<CreateVehiclePresenter>());
            services.AddScoped<ICreateVehicleOutputPort>(sp => sp.GetService<CreateVehiclePresenter>());

            services.AddScoped<CreateRentalPresenter>();
            services.AddScoped<ICreateRentalPresenter>(sp => sp.GetService<CreateRentalPresenter>());
            services.AddScoped<ICreateRentalOutputPort>(sp => sp.GetService<CreateRentalPresenter>());

            services.AddScoped<ReturnRentalPresenter>();
            services.AddScoped<IReturnRentalPresenter>(sp => sp.GetService<ReturnRentalPresenter>());
            services.AddScoped<IReturnRentalOutputPort>(sp => sp.GetService<ReturnRentalPresenter>());

            return services;
        }
    }
}
