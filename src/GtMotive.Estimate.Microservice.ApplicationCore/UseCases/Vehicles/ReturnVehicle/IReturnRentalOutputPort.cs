namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Return Rental Output Port.
    /// </summary>
    public interface IReturnRentalOutputPort : IOutputPortStandard<ReturnRentalOutput>, IOutputPortBadRequest
    {
    }
}
