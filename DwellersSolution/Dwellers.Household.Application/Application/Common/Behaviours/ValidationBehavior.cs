﻿using FluentValidation;
using MediatR;

namespace Dwellers.Household.Application.Common.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        {
            private readonly IEnumerable<IValidator<TRequest>> _validators;

            public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
            {
                _validators = validators;
            }

            public async Task<TResponse> Handle(
            TRequest request,
             RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
            )

        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Count != 0)
            {
                var errorMessages = failures.Select(failure => $"{failure.PropertyName}: {failure.ErrorMessage}").ToList();
                var formattedErrorMessage = string.Join(Environment.NewLine, errorMessages);
                throw new ValidationException(formattedErrorMessage);
            }

            return await next();
        }
    }
}
