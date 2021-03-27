using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using JongSnamFootball.Entities.Constants;
using JongSnamFootball.Entities.CustomErrors;
using JongSnamFootball.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JongSnam.Services.Attributes
{
    /// <summary>
    /// Authorize token header filter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter" />
    public class AuthorizeTokenHeaderFilter : IAuthorizationFilter
    {
        private readonly IAuthenticationManager _authenticationManager;

        public AuthorizeTokenHeaderFilter(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        /// <summary>
        /// Called early in the filter pipeline to confirm request is authorized.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext" />.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.Filters.Any(x => x is IAllowAnonymousFilter))
            {
                var authorizedHeader = context.HttpContext.Request.Headers.FirstOrDefault(header => header.Key == AuthenticationConstant.Authorization);
                var accessToken = authorizedHeader.Value.FirstOrDefault();
                var userHeader = context.HttpContext.Request.Headers.FirstOrDefault(header => header.Key == AuthenticationConstant.User);
                var user = userHeader.Value.FirstOrDefault();
                var passwordHeader = context.HttpContext.Request.Headers.FirstOrDefault(header => header.Key == AuthenticationConstant.Password);
                var password = passwordHeader.Value.FirstOrDefault();

                if (string.IsNullOrWhiteSpace(accessToken))
                {
                    context.Result = UnauthorizedResult(context);
                }
                else
                {
                    // For Swagger
                    if (accessToken.Contains("test"))
                    {
                        user = "p@m.com";
                        password = "password";
                    }

                    try
                    {
                        var result = _authenticationManager.CheckIsLoggedIn(user, password).Result;

                        if (result)
                        {

                        }
                        else
                        {
                            context.Result = UnauthorizedResult(context);
                        }
                    }
                    catch (Exception)
                    {
                        context.Result = UnauthorizedResult(context);
                    }
                    //try
                    //{
                    //    var userAuthenticationManager = (IUserAuthenticationManager)context.HttpContext.RequestServices.GetService(typeof(IUserAuthenticationManager));

                    //    var userAuthenticatedDto = userAuthenticationManager.IntrospectReferenceTokenToUserAuthenticatedModel(accessToken).Result;
                    //    if (userAuthenticatedDto.Active)
                    //    {
                    //        var mapper = (IMapper)context.HttpContext.RequestServices.GetService(typeof(IMapper));
                    //        userAuthenticatedDto.RefToken = accessToken;
                    //        context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(mapper.Map<Claim[]>(userAuthenticatedDto), "UcoAuthentication"));
                    //    }
                    //    else
                    //    {
                    //        context.Result = UnauthorizedResult(context);
                    //    }
                    //}
                    //catch (Exception)
                    //{
                    //    context.Result = UnauthorizedResult(context);
                    //}
                }
            }
        }

        private UnauthorizedObjectResult UnauthorizedResult(AuthorizationFilterContext context)
        {
            var routePath = string.Join(@"/", context.RouteData.Values.Select(item => item.Value));
            var responseObject = new UnauthorizedError(routePath);
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return new UnauthorizedObjectResult(responseObject);
        }
    }
}
