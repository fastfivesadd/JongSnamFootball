using Microsoft.AspNetCore.Mvc;

namespace JongSnam.Services.Attributes
{
    /// <summary>
    /// Authorize token header attribute
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.TypeFilterAttribute" />
    public class AuthorizeTokenHeaderAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeTokenHeaderAttribute"/> class.
        /// </summary>
        public AuthorizeTokenHeaderAttribute() : base(typeof(AuthorizeTokenHeaderFilter))
        {
        }
    }
}
