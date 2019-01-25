﻿using Api.Helper.ContentWrapper.Core.Extensions;
using Api.Helper.ContentWrapper.Core.WrapperModel;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Api.Helper.ContentWrapper.Core.Filters
{
    public class ModelStateFeatureFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var state = context.ModelState;
            context.HttpContext.Features.Set<ModelStateFeature>(new ModelStateFeature(state));
            if (!state.IsValid)
            {
               throw new ApiException("Your Request is not valid", 500, ModelStateExtension.AllErrors(state));
            }
            await next();
        } 
    }
}
