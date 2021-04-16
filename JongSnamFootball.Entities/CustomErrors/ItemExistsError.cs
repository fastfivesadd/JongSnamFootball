using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnamFootball.Entities.CustomErrors
{
    /// <summary>
    /// Item exists error.
    /// </summary>
    public sealed class ItemExistsError : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemExistsError"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="title">The title.</param>
        public ItemExistsError(string instance, string detail, string title)
        {
            new ProblemDetails
            {
                Detail = detail,
                Type = ToString(),
                Status = StatusCodes.Status409Conflict,
                Title = title,
                Instance = instance
            };
        }
    }
}
