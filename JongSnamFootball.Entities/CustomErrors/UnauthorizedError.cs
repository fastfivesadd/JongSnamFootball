using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnamFootball.Entities.CustomErrors
{
    /// <summary>
    /// Unauthorized error.
    /// </summary>
    public sealed class UnauthorizedError : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedError"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="title">The title.</param>
        public UnauthorizedError(string instance, string detail = "Access denied", string title = "Unauthorized")
        {
            new ProblemDetails
            {
                Detail = detail,
                Type = ToString(),
                Status = StatusCodes.Status401Unauthorized,
                Title = title,
                Instance = instance
            };
        }
    }
}
