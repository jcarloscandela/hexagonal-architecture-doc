namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Outport Bad Request.
    /// </summary>
    public interface IOutputPortBadRequest
    {
        /// <summary>
        /// Bad Request.
        /// </summary>
        /// <param name="message">Bad request message.</param>
        void BadRequestHandle(string message);
    }
}
