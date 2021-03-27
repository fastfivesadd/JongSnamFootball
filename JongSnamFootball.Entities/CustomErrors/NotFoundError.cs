using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnamFootball.Entities.CustomErrors
{
    /// <summary>
    /// Not found error.
    /// </summary>
    public sealed class NotFoundError : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundError"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="title">The title.</param>
        public NotFoundError(string instance, string detail, string title)
        {
            new ProblemDetails
            {
                Detail = detail,
                Type = ToString(),
                Status = StatusCodes.Status404NotFound,
                Title = title,
                Instance = instance
            };
        }
    }
}
