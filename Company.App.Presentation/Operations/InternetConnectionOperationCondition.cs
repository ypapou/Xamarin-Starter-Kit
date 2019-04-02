using System.Threading;
using System.Threading.Tasks;
using Company.App.Application.Connectivity;
using Company.App.Common.Resources;
using Company.App.Infrastructure.Connectivity;
using FlexiMvvm.Operations;

namespace Company.App.Presentation.Operations
{
    internal class InternetConnectionOperationCondition : OperationCondition
    {
        public override Task<bool> CheckAsync(OperationContext context, CancellationToken cancellationToken)
        {
            var connectivityService = context.DependencyProvider.Get<IConnectivityService>();

            if (connectivityService.IsConnected)
            {
                return Task.FromResult(true);
            }

            throw new ConnectivityException(Strings.Exception_NoInternetConnection);
        }
    }
}
