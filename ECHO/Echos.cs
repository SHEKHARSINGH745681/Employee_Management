using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Echo
{
    public  sealed class Echos
    {
        public string Status { get; set; } = null!;
        public string? Message { get; set; }

        public Echos(string status, string? message)
        {
            Status = status;
            Message = message;
        }
        // Returns a success response with data.
        public static ActionResult Ok(object data)
        {
            return new OkObjectResult(data);
        }

        /// Returns a success response with a message.
        public static ActionResult Ok(string message)
        {
            var response = new Echos("Success", message);
            return new OkObjectResult(response);
        }

        /// Returns a bad request response with a message.
        public static ActionResult BadRequest(string message)
        {
            var response = new Echos("Error", message);
            return new BadRequestObjectResult(response);
        }

        /// Returns a not found response with a message.
        public static ActionResult NotFound(string message)
        {
            var response = new Echos("Error", message);
            return new NotFoundObjectResult(response);
        }

        /// Returns an unauthorized response with a message.
        public static ActionResult Unauthorized(string message)
        {
            var response = new Echos("Error", message);
            return new UnauthorizedObjectResult(response);
        }

        /// Returns an internal server error response with a message.
        public static ActionResult InternalServerError(string message)
        {
            var response = new Echos("Error", message);
            return new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

}
