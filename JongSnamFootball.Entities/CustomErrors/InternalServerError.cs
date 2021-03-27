using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnamFootball.Entities.CustomErrors
{
    /// <summary>
    /// Internal server error.
    /// </summary>
    public sealed class InternalServerError : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerError"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="title">The title.</param>
        public InternalServerError(string instance, string detail, string title)
        {
            new ProblemDetails
            {
                Detail = detail,
                Type = ToString(),
                Status = StatusCodes.Status500InternalServerError,
                Title = title,
                Instance = instance
            };
        }
    }
}
