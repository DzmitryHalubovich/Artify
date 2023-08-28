using Artify.Repositories.Contracts;
using Artify.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Artify.Presentation.ActionFilters
{
    public class AuthorExistsFilterAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repositoryManager;

        public AuthorExistsFilterAttribute(IRepositoryManager repositoryManager)
        {
            _repositoryManager=repositoryManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var authorId = context.RouteData.Values["authorId"];

            try
            {
               //var authorExists = await _repositoryManager.Author.GetShortAuthor(new Guid(authorId.ToString()));
            }
            catch
            {
                context.Result = new BadRequestObjectResult(
                 $"Author doesn't exist or wrong author id. Controller: {controller}, action: {action}");

                return;
            }

            await next.Invoke();
        }
    }
}
