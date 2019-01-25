﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Api.Helper.ContentWrapper.Core.WrapperModel
{
    public class ApiError
    {
        public bool IsError { get; set; }
        public bool IsValidationError { get; set; }
        public string ExceptionMessage { get; set; }
        public string Details { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public ApiError(string message)
        {
            this.ExceptionMessage = message;
            this.IsError = true;
            this.IsValidationError = false;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            this.IsError = true;
            this.IsValidationError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                this.ExceptionMessage = "Please correct the specified validation errors and try again.";
                this.ValidationErrors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();

            }
            else
            {
                this.ExceptionMessage = "Please correct the specified validation errors and try again.";
            }
        } 
    }
}
