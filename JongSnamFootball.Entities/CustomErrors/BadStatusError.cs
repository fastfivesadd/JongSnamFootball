using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnamFootball.Entities.CustomErrors
{
    /// <summary>
    /// Bad status error.
    /// </summary>
    public sealed class BadStatusError : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadStatusError"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="title">The title.</param>
        public BadStatusError(string instance, string detail, string title)
        {
            new ProblemDetails
            {
                Detail = detail,
                Type = ToString(),
                Status = StatusCodes.Status400BadRequest,
                Title = title,
                Instance = instance
            };
        }
    }
}
