using EmployeeAdminPortal.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Echo
{
    public sealed class Echos
    {
        public string Status { get; set; } = null!;
        public string? Message { get; set; }

        public Echos(string status, string? message)
        {
            Status = status;
            Message = message;
        }

        // success response with a message.
        public static ActionResult Ok(object data)
        {
            return new OkObjectResult(data);
        }
        //200
        public static ActionResult<T?> OkIfNotNull<T>(T? data) where T : class
        {
            if (data is null)
                return NotFound("Requested entity not found.");
            return new OkObjectResult(data);
        }
        //200
        public static ActionResult Ok(string message)
        {
            var response = new Echos("Success", message);
            return new OkObjectResult(response);
        }
        //400
        public static ActionResult BadRequest(string message)
        {
            var response = new Echos("Error", message);
            return new BadRequestObjectResult(response);
        }

        //404
        public static ActionResult NotFound(string message)
        {
            var response = new Echos("Error", message);
            return new NotFoundObjectResult(response);
        }

        //401
        public static ActionResult Unauthorized(string message)
        {
            var response = new Echos("Error", message);
            return new UnauthorizedObjectResult(response);
        }
         //ISE 500
        public static ActionResult InterServerError(string message)
        {
            var response = new Echos("Error", message);
            return new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        internal static ActionResult<Echos> BadRequest(Echos echos)
        {
            throw new NotImplementedException();
        }
    }

}
