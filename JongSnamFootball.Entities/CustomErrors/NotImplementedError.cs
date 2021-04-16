using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnamFootball.Entities.CustomErrors
{
    /// <summary>
    /// Not Implemented Error
    /// </summary>
    /// <seealso cref="Kob.Uco.Gateways.Backoffice.Entities.Dtos.BaseResponseDto{Microsoft.AspNetCore.Mvc.ProblemDetails}" />
    public class NotImplementedError : ProblemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotImplementedError"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="detail">The detail.</param>
        /// <param name="title">The title.</param>
        public NotImplementedError(string instance, string detail, string title)
        {
            new ProblemDetails
            {
                Detail = detail,
                Type = ToString(),
                Status = StatusCodes.Status501NotImplemented,
                Title = title,
                Instance = instance
            };
        }
    }
}
