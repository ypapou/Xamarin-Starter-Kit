using System;
using System.Threading;
using System.Threading.Tasks;
using Company.App.Application.UserInteraction;
using Company.App.Resources;
using FlexiMvvm.Exceptions;
using FlexiMvvm.Operations;
using Microsoft.AppCenter.Crashes;

namespace Company.App.Presentation.Operations
{
    public class ErrorHandler : IErrorHandler
    {
        public async Task HandleAsync(OperationContext context, OperationError<Exception> error, CancellationToken cancellationToken)
        {
            var userInteractionService = context.DependencyProvider.Get<IUserInteractionService>();

            if (error.Exception is IUserFriendlyException userFriendlyException)
            {
                await userInteractionService.ShowErrorAsync(
                    Strings.UserError_Dialog_Tile,
                    userFriendlyException.Message,
                    Strings.UserError_Dialog_Action_Ok);
            }
            else
            {
                Crashes.TrackError(error.Exception);

                await userInteractionService.ShowErrorAsync(
                    Strings.UserError_Dialog_Tile,
                    Strings.UserError_Dialog_Message_Generic,
                    Strings.UserError_Dialog_Action_Ok);
            }
        }
    }
}
